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