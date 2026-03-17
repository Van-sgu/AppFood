using FoodStreet.Services;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;


namespace FoodStreet;

public partial class MainPage : ContentPage
{
    private List<POI> _poiList = new();
    private readonly Locations _locationService = new Locations();
    private readonly GeofenceService _geofenceService = new GeofenceService();
    private readonly Data _dataService = new Data();

    public MainPage()
    {
        InitializeComponent();

        //Đăng ký sự kiện LocationChanged ngay tại đây
        _locationService.LocationChanged += LocationChangedReceived;
    }
    private void LocationChangedReceived(object? sender, Location location)
    {
        var triggeredPoi = _geofenceService.GetTriggeredPoi(location, _poiList);
        var nearbyPois = _geofenceService.GetActivePois(location, _poiList);

        if (triggeredPoi != null)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            { 
            });
        }
        MainThread.BeginInvokeOnMainThread(() => { map.IsShowingUser = true; });
        //cập nhật giao diện (UI)
        MainThread.BeginInvokeOnMainThread(() =>
            {
                if (map != null && location != null)
                {
                    //var mapSpan = MapSpan.FromCenterAndRadius(
                    //    new Location(location.Latitude, location.Longitude),
                    //    Distance.FromKilometers(0.5));
                    ////Di chuyển camera bản đồ theo người dùng
                    ////map.MoveToRegion(mapSpan);

                    //// Hiển thị chấm xanh vị trí người dùng
                    map.IsShowingUser = true;

                    // Nếu tìm thấy quán ăn gần nhất (ưu tiên cao nhất)
                    if (nearbyPois.Any())
                    {
                        var topStore = nearbyPois.First();
                        
                        System.Diagnostics.Debug.WriteLine($"Đang ở trong vùng của: {topStore.Name}");
                    }
                }
            });
        }
    

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //Bắt đầu nghe vị trí khi trang xuất hiện
        var suVanHanh = new Location(10.7765, 106.6675);
        var mapSpan = MapSpan.FromCenterAndRadius(suVanHanh, Distance.FromKilometers(0.5));

        if (map != null)
        {
            // Buộc bản đồ phải nhảy về Sư Vạn Hạnh ngay lập tức
            map.MoveToRegion(mapSpan);

        }
        try
        {
            _poiList = await _dataService.GetRestaurantsAsync(); // Lấy data từ SQL Server VS

            // Xóa Pin cũ và vẽ Pin mới từ Database lên bản đồ
            map.Pins.Clear();
            map.MapElements.Clear();

            foreach (var poi in _poiList)
            {
                var poiLocation = new Location(poi.Latitude, poi.Longitude);

                // --- BƯỚC 2: CẮM DẤU GHIM (PINS) ---
                var pin = new Pin
                {
                    Label = poi.Name,
                    Address = $"Ưu tiên: {poi.Priority}",
                    Type = PinType.Place,
                    Location = poiLocation
                };
                map.Pins.Add(pin);

                // --- BƯỚC 3: VẼ VÒNG TRÒN KHOANH VÙNG (CIRCLES) ---
                if (poi.Latitude != 0 && poi.Longitude != 0)
                {
                    // Vẽ Vòng tròn khoanh vùng
                    var circle = new Circle
                    {
                        Center = poiLocation,
                        Radius = Distance.FromMeters(poi.Radius > 0 ? poi.Radius : 100), // Nếu radius <= 0 thì mặc định 100m
                        StrokeColor = Color.FromArgb("#88FF0000"), // Viền đỏ đậm (Alpha 88)
                        StrokeWidth = 8,                           // Tăng độ dày viền để dễ quan sát
                        FillColor = Color.FromArgb("#44FF0000")      // Nền hồng nhạt (Alpha 44)
                    };

                    // Thêm vào MapElements
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        map.MapElements.Add(circle);
                    });
                }
            }
            await _locationService.StartListening();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Lỗi nạp dữ liệu SQL: {ex.Message}");
        }

        
    }
    private async void OnSettingsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SettingsPage());
    }
    private void OnCounterClicked(object? sender, EventArgs e)
    {
        // Di chuyển đến vị trí cố định để test bản đồ
        var suVanHanh = new Location(10.7765, 106.6675);
        map.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(10.7626, 106.6602), Distance.FromKilometers(1)));
        
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        //Dừng lấy vị trí để tiết kiệm pin 
        _locationService.StopListening();
    }
    private async void OnShowListClicked(object sender, EventArgs e)
    {
        if (_poiList == null || !_poiList.Any())
        {
            await DisplayAlert("Thông báo", "Đang tải danh sách nhà hàng...", "OK");
            return;
        }

        //Lấy danh sách tên các nhà hàng từ POI list (đã nạp từ SQL)
        string[] restaurantNames = _poiList
            .OrderBy(p => p.Priority)
            .Select(p => p.Name)
            .ToArray();

        // Hiển thị menu chọn nhanh
        string action = await DisplayActionSheet("Nhà hàng gợi ý", "Đóng", null, restaurantNames);

        // Nếu người dùng chọn một quán, di chuyển bản đồ tới đó
        var selectedPoi = _poiList.FirstOrDefault(p => p.Name == action);
        if (selectedPoi != null)
        {
            var location = new Location(selectedPoi.Latitude, selectedPoi.Longitude);

            // Di chuyển camera đến quán được chọn
            await MainThread.InvokeOnMainThreadAsync(() => {
                map.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(0.3)));
            });
        }
    }
}