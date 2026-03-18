using FoodStreet.Data;
using FoodStreet.Models;
using FoodStreet.Services;

using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Maps;


namespace FoodStreet.Pages;


public partial class Map : ContentPage
{
    private readonly GeofenceService geofenceService = new GeofenceService();
    private readonly DataServices _dbService;
    private readonly Notifications _notifyService;
    List <POI> locations = new();
    Dictionary<POI, Pin> _Pins = new();

    private CancellationTokenSource? _trackingCts;

    public Map(DataServices dbService, Notifications notifyService)
    {
        InitializeComponent();
        _dbService = dbService;
        _dbService = dbService;
        _notifyService = notifyService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadData();
        StartLocationTracking();
        DefaultLoc();
    }
    private void DefaultLoc()
    {
        try
        {
            var vinhkhanh = new Location(10.7765, 106.6675);
            var mapSpan = MapSpan.FromCenterAndRadius(vinhkhanh, Distance.FromKilometers(0.5));
            map.MoveToRegion(mapSpan);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Lỗi khi di chuyển map: {ex.Message}");
        }
    }
    private async Task LoadData()
    {
        try
        {
            locations = await _dbService.GetItemsAsync();
            if (locations == null || !locations.Any()) return;

            // Sử dụng một màu xanh 
            var themeColor = Color.FromRgba(0, 153, 255, 51);

            foreach (var loc in locations)
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
        }
        catch (Exception ex) 
        { 
            // Sửa lỗi DisplayAlert Obsolete ở đây
            await DisplayAlert("Lỗi", ex.Message, "OK"); 
        }
    }
    private void HighlightPoi(List<POI> activePois)
    {
        foreach (var item in _Pins)
        {
            item.Value.Label = item.Key.Name;
            item.Value.Type = PinType.Place;
        }
        foreach (var poi in activePois)
        {
            if (_Pins.TryGetValue(poi, out var pin))
            {
                pin.Label = $"⭐ {poi.Name}";
                pin.Type = PinType.SavedPin;
            }
        }
    }
    private async void StartLocationTracking()
    {
        _trackingCts = new CancellationTokenSource();
        try
        {
            while (!_trackingCts.Token.IsCancellationRequested)
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                var loc = await Geolocation.Default.GetLocationAsync(request, _trackingCts.Token);

                if (loc != null)
                {
                    var activePois = geofenceService.CheckNearby(loc, locations);

                    if (activePois != null)
                    {
                        HighlightPoi(activePois);
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
}