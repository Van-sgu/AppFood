using FoodStreet.Models;
using FoodStreet.Services;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace FoodStreet.Services;

public class GeofenceService
{
    public List<POI> CheckNearby(Location userLocation, List<POI> pois)
    {
        List<POI> nearby = new();

        if (userLocation == null || pois == null) return nearby;

        foreach (var poi in pois)
        {
            double distanceKm = Location.CalculateDistance(
                userLocation.Latitude, userLocation.Longitude,
                poi.Latitude, poi.Longitude,
                DistanceUnits.Kilometers);

            double distanceMeters = distanceKm * 1000;

            if (distanceMeters <= poi.Radius)
            {
                nearby.Add(poi);
            }
        }
        return nearby;
    }
}