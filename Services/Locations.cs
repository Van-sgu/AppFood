namespace FoodStreet;

public class LocationService
{
    // Sự kiện để báo cho giao diện cập nhật
    public event EventHandler<Location>? LocationChanged;

    public async Task<bool> StartListening()
    {
        try
        {
            // 1. Kiểm tra quyền
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }

            if (status == PermissionStatus.Granted)
            {
                // Giải pháp tạm thời: Lấy vị trí 1 lần để tránh crash Service
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                var location = await Geolocation.Default.GetLocationAsync(request);

                if (location != null)
                {
                    LocationChanged?.Invoke(this, location);
                    return true;
                }
            }
            return false;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Lỗi GPS: {ex.Message}");
            return false;
        }
    }

    public void StopListening()
    {
        // Khi dùng GetLocationAsync thì không cần hủy đăng ký liên tục
    }
}