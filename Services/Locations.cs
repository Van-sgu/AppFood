//using Microsoft.Maui.Devices.Sensors;

//namespace FoodStreet;

//public class Locations
//{
//    public event EventHandler<Location> LocationChanged;

//    private bool _isListening = false;

//    public async Task<bool> StartListening()
//    {
//        if (_isListening) return true;

//        try
//        {
//            // Kiểm tra quyền
//            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
//            if (status != PermissionStatus.Granted)
//            {
//                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
//            }

//            Geolocation.Default.LocationChanged += Geolocation_LocationChanged;


//            var request = new GeolocationListeningRequest(
//                GeolocationAccuracy.Best,
//                TimeSpan.FromSeconds(5));

//            var success = await Geolocation.Default.StartListeningForegroundAsync(request);

//            return success;

//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Lỗi GPS: {ex.Message}");
//            return false;
//        }
//    }

//    private void Geolocation_LocationChanged(object? sender, GeolocationLocationChangedEventArgs e)
//    {
//        LocationChanged?.Invoke(this, e.Location);

//    }

//    public void StopListening()
//    {
//        if (!_isListening) return;

//        Geolocation.Default.LocationChanged -= Geolocation_LocationChanged;
//        Geolocation.Default.StopListeningForeground();
//        _isListening = false;

//    }
//}
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices.Sensors;

namespace FoodStreet.Services;

public class LocationService
{
    public event Action<Location>? OnLocationChanged;

    bool isRunning = false;

    public async Task StartAsync()
    {
        if (isRunning)
            return;

        isRunning = true;

        var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

        if (status != PermissionStatus.Granted)
            return;

        while (isRunning)
        {
            try
            {
                var request = new GeolocationRequest(
                    GeolocationAccuracy.Best,
                    TimeSpan.FromSeconds(5));

                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    OnLocationChanged?.Invoke(location);
                }
            }
            catch { }

            await Task.Delay(3000);
        }
    }

    public void Stop()
    {
        isRunning = false;
    }
}