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
        _notifyService = notifyService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CheckAndRequestLocationPermission();
        await LoadData();
        StartLocationTracking();
        DefaultLoc();
    }
    private async Task CheckAndRequestLocationPermission()
    {
        var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
        if (status != PermissionStatus.Granted)
        {
            await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        }
    }
    private void DefaultLoc()
    {
        try
        {
            var vinhkhanh = new Location(10.76198, 106.70226);
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

            var themeColor = Color.FromRgba(0, 153, 255, 51);

            foreach (var loc in locations)
            {
                var location = new Location(loc.Latitude, loc.Longitude);

                var pin = new Pin
                {
                    Label = loc.Name,
                    Location = location,
                    Type = PinType.Place,
                    Address = loc.Description
                };

                pin.InfoWindowClicked += async (s, e) =>
                {
                    await Navigation.PushAsync(new DetailPoi(loc));
                };
                map.Pins.Add(pin);
                if (!_Pins.ContainsKey(loc))
                    _Pins.Add(loc, pin);
                //Vẽ vòng tròn bán kính
                map.MapElements.Add(new Circle
                {
                    Center = location,
                    Radius = new Distance(10),
                    StrokeColor = Colors.Blue,
                    StrokeWidth = 2,
                    FillColor = themeColor
                });
            }
        }
        catch (Exception ex) 
        {
            await Shell.Current.DisplayAlert("Lỗi nạp dữ liệu", ex.Message, "OK");
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
    public void MoveToLocation(double lat, double lon)
    {
        var location = new Location(lat, lon);

        var mapSpan = Microsoft.Maui.Maps.MapSpan.FromCenterAndRadius(location, Microsoft.Maui.Maps.Distance.FromKilometers(0.1));

        map.MoveToRegion(mapSpan);
        var targetPin = _Pins.Values.FirstOrDefault(p =>
            Math.Abs(p.Location.Latitude - lat) < 0.0001);
        if (targetPin != null)
        {
            foreach (var p in _Pins.Values) p.Type = PinType.Place;
            targetPin.Type = PinType.SearchResult;
        }
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