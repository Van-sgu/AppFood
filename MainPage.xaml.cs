using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace FoodStreet;

public partial class MainPage : ContentPage
{
    // 1. Khai báo Service (Chỉ khai báo 1 lần)
    private readonly LocationService _locationService = new LocationService();

    public MainPage()
    {
        InitializeComponent();

        // 2. Đăng ký sự kiện LocationChanged ngay tại đây
        _locationService.LocationChanged += LocationChangedReceived;
    }
    private void LocationChangedReceived(object? sender, Location location)
    {
            // Bắt buộc dùng MainThread để cập nhật giao diện (UI)
            MainThread.BeginInvokeOnMainThread(() =>
            {
                if (map != null && location != null)
                {
                    var mapSpan = MapSpan.FromCenterAndRadius(
                        new Location(location.Latitude, location.Longitude),
                        Distance.FromKilometers(0.5));
                    //Di chuyển camera bản đồ theo người dùng
                    map.MoveToRegion(mapSpan);

                    // Hiển thị chấm xanh vị trí người dùng
                    map.IsShowingUser = true;
                }
            });
        }
    

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //Bắt đầu nghe vị trí khi trang xuất hiện
        try
        {
            await _locationService.StartListening();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Lỗi GPS: {ex.Message}");
        }
    }

    private void OnCounterClicked(object? sender, EventArgs e)
    {
        // Di chuyển đến vị trí cố định để test bản đồ
        if (map != null)
        {
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(10.7626, 106.6602), Distance.FromKilometers(1)));
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        //Dừng lấy vị trí để tiết kiệm pin 
        _locationService.StopListening();
    }
}