using Microsoft.Maui.Devices.Sensors;

namespace FoodStreet;

public class LocationService
{
    public event EventHandler<Location> LocationChanged;

    private bool _isListening = false;

    public async Task<bool> StartListening()
    {
        if (_isListening) return true;

        try
        {
            // 1. Kiểm tra quyền
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }

            Geolocation.Default.LocationChanged += Geolocation_LocationChanged;

            // Độ chính xác cao nhất, cập nhật tối thiểu mỗi 5 giây hoặc khi di chuyển
            var request = new GeolocationListeningRequest(
                GeolocationAccuracy.Best,
                TimeSpan.FromSeconds(5));

            var success = await Geolocation.Default.StartListeningForegroundAsync(request);

            if (success)
            {
                _isListening = true;
                Console.WriteLine("GPS: Đang chạy liên tục...");
            }

            return success;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi GPS: {ex.Message}");
            return false;
        }
    }

    private void Geolocation_LocationChanged(object? sender, GeolocationLocationChangedEventArgs e)
    {
        // Khi hệ thống nhận tọa độ mới, nó tự gọi hàm này
        LocationChanged?.Invoke(this, e.Location);
        Console.WriteLine($"GPS: Tọa độ mới {e.Location.Latitude}, {e.Location.Longitude}");
    }

    public void StopListening()
    {
        if (!_isListening) return;

        Geolocation.Default.LocationChanged -= Geolocation_LocationChanged;
        Geolocation.Default.StopListeningForeground();
        _isListening = false;
        Console.WriteLine("GPS: Đã dừng.");
    }
}