using FoodStreet.Data;
using FoodStreet.Models;
using FoodStreet.Services;

using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Maps;
using System.Net.NetworkInformation;

namespace FoodStreet.Pages;

public partial class Map : ContentPage
{
    private readonly DataServices _dataService = new DataServices();
    private readonly Notifications _notifyService = new Notifications();
    private List<POI> _locations = new();
    private Dictionary<POI, Pin> _Pins = new();

    private int? _lastTriggeredId = null; // Lưu ID quán vừa đọc để tránh lặp
    private CancellationTokenSource? _trackingCts;

    public Map()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadData();
        await _notifyService.LoadPoisFromSqlAsync(); //Nạp dữ liệu từ SQL server
        StartLocationTracking();
        //Bắt đầu nghe vị trí khi trang xuất hiện
        var vinhkhanh = new Location(10.7765, 106.6675);
        map.MoveToRegion(MapSpan.FromCenterAndRadius(vinhkhanh, Distance.FromKilometers(0.5)));
    }
    private async Task LoadData()
    {
        try
        {
            _locations = await _dataService.GetPoisFromDbAsync();
            if (_locations == null || !_locations.Any()) return;

            map.Pins.Clear();
            map.MapElements.Clear();
            _Pins.Clear();
            // Sử dụng một màu xanh 
            var themeColor = Color.FromArgb("#330099FF");

            foreach (var loc in _locations)
            {
                var location = new Location(loc.Latitude, loc.Longitude);

                var pin = new Pin
                {
                    Label = loc.Name,
                    Location = location,
                    Type = PinType.Place
                };

                pin.InfoWindowClicked += async (s, e) =>
                {
                    // Chuyển sang trang DetailPoi và truyền dữ liệu quán ăn
                    await Navigation.PushAsync(new DetailPoi(loc));
                };
                map.Pins.Add(pin);
                _Pins.Add(loc, pin);
                //Vẽ vòng tròn bán kính
                map.MapElements.Add(new Circle
                {
                    Center = location,
                    Radius = new Distance(30),
                    StrokeColor = Colors.Blue,
                    StrokeWidth = 2,
                    FillColor = themeColor
                });
            }

            // Zoom vào vùng có dữ liệu
            map.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Location(_locations[0].Latitude, _locations[0].Longitude), Distance.FromMeters(500)));
        }
        catch (Exception ex) { await DisplayAlert("Lỗi", ex.Message, "OK"); }
    }
    private void HighlightPoi(POI activePoi)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            // Reset tất cả các Pin về mặc định
            foreach (var entry in _Pins)
            {
                entry.Value.Label = entry.Key.Name;
                entry.Value.Type = PinType.Place;
            }

            // Làm nổi bật Pin của quán đang ở gần
            if (_Pins.TryGetValue(activePoi, out var pin))
            {
                pin.Label = "⭐ Đang ở gần: " + activePoi.Name;
                pin.Type = PinType.SavedPin;
                //pin.ShowInfoWindow(); // Tự động hiện bảng tên

            }
        });
    }
    private async void StartLocationTracking()
    {
        _trackingCts = new CancellationTokenSource();
        try
        {
            while (!_trackingCts.Token.IsCancellationRequested)
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                var location = await Geolocation.Default.GetLocationAsync(request, _trackingCts.Token);

                if (location != null)
                {
                    var activePoi = _notifyService.GetNearestPoi(location, 30);

                    if (activePoi != null)
                    {
                        // Gọi thuyết minh (Hàm này đã có logic Play/Pause bên trong)
                        await _notifyService.SpeakAsync(activePoi);
                        HighlightPoi(activePoi);
                    }
                }
                await Task.Delay(5000, _trackingCts.Token);
            }
        }
        catch (Exception) { } // Tắt máy bình thường
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _trackingCts?.Cancel();
        _trackingCts?.Dispose();
        _trackingCts = null;
        _notifyService.StopCurrentSpeech();
    }
    private void OnLocationChanged(Location userLocation)
    {
        var poi = _notifyService.GetNearestPoi(userLocation, 30);

        if (poi != null)
        {
            // Tự động phát thuyết minh
            _ = _notifyService.SpeakAsync(poi);
        }
    }
    private void OnPlayClicked(object sender, EventArgs e)
    {
        _notifyService.Play();
        UpdateButtonStates(true);
    }
    private void OnPauseClicked(object sender, EventArgs e)
    {
        _notifyService.Pause();
        UpdateButtonStates(false);
    }
    private void UpdateButtonStates(bool isPlaying)
    {
        if (BtnPlay != null) BtnPlay.IsEnabled = !isPlaying;
        if (BtnPause != null) BtnPause.IsEnabled = isPlaying;
    }
}