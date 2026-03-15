using FoodStreet.Services;

namespace FoodStreet.Services;

public class GeofenceService
{
    private readonly TimeSpan _cooldownTime = TimeSpan.FromMinutes(5);
    public List<POI> GetActivePois(Location userLocation, List<POI> allPois)
    {
        if (userLocation == null || allPois == null) return new List<POI>();

        // Sử dụng LINQ để lọc và sắp xếp theo mức độ ưu tiên
        return allPois
            .Select(poi => new
            {
                Data = poi,
                // Tính khoảng cách (mét)
                Distance = Location.CalculateDistance(userLocation,
                           new Location(poi.Latitude, poi.Longitude),
                           DistanceUnits.Kilometers) * 1000
            })
            .Where(x => x.Distance <= x.Data.Radius) // Lọc quán trong bán kính
            .OrderBy(x => x.Data.Priority)           // Ưu tiên quán quan trọng trước (1, 2, 3...)
            .Select(x => x.Data)
            .ToList();
    }

    public POI? GetTriggeredPoi(Location userLocation, List<POI> allPois)
    {
        if (userLocation == null || allPois == null) return null;

        // Tìm quán ăn gần nhất và thỏa mãn điều kiện
        var activePoi = allPois
            .Select(poi => new
            {
                Data = poi,
                Distance = Location.CalculateDistance(userLocation,
                           new Location(poi.Latitude, poi.Longitude),
                           DistanceUnits.Kilometers) * 1000
            })
            .Where(x => x.Distance <= x.Data.Radius)
            .OrderBy(x => x.Data.Priority)
            .Select(x => x.Data)
            .FirstOrDefault();

        if (activePoi != null)
        {
            // KIỂM TRA CHỐNG SPAM (DEBOUNCE/COOLDOWN)
            var timeSinceLastTrigger = DateTime.Now - activePoi.LastTriggered;

            if (timeSinceLastTrigger >= _cooldownTime)
            {
                // Cập nhật lại thời gian kích hoạt để bắt đầu cooldown mới
                activePoi.LastTriggered = DateTime.Now;
                return activePoi;
            }
        }

        return null;
    }
}