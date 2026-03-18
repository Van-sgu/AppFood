using FoodStreet.Data;
using FoodStreet.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Maui.Devices.Sensors;

namespace FoodStreet.Services;

public class AutoNarrationEngine
{
    DataServices _dbService;
    private bool _isTracking = false;
    
    private readonly Dictionary<int, DateTime> _playbackHistory = new();
    private const double CooldownMinutes = 2;

    public AutoNarrationEngine(DataServices dbService)
    {
        _dbService = dbService;
    }
    public async Task StartEngineAsync()
    {
        if (_isTracking) return;
        var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        if (status != PermissionStatus.Granted) return;

        _isTracking = true;

        while (_isTracking)
        {
            try
            {
                var location = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Medium));

                if (location != null)
                {
                    await ProcessNearbyPois(location);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Location Error: {ex.Message}");
            }

            // Chờ 5 giây trước khi kiểm tra tiếp
            await Task.Delay(TimeSpan.FromSeconds(5));
        }
    }

    private async Task ProcessNearbyPois(Location userLoc)
    {
        // Thay vì lấy HẾT database về (rất nặng nếu dùng SQL Server), 
        // ta nên lấy danh sách POI trong một phạm vi nhất định từ Server.
        var allPois = await _dbService.GetItemsAsync();

        // Lọc các điểm nằm trong bán kính hoạt động
        var activePois = allPois.Where(p => 
        {
            double dist = Location.CalculateDistance(userLoc, p.Latitude, p.Longitude, DistanceUnits.Kilometers) * 1000;
            return dist <= p.Radius;
        }).ToList();

        if (activePois.Any())
        {
            // Ưu tiên: 1. Priority cao nhất -> 2. Khoảng cách gần nhất
            var target = activePois
                .OrderByDescending(p => p.Priority)
                .ThenBy(p => Location.CalculateDistance(userLoc, p.Latitude, p.Longitude, DistanceUnits.Kilometers))
                .FirstOrDefault();

            if (target != null && CanPlay(target.Id))
            {
                await ExecuteTts(target);
            }
        }
    }
    

    private bool CanPlay(int poiId)
    {
        if (!_playbackHistory.ContainsKey(poiId)) return true;
        return (DateTime.Now - _playbackHistory[poiId]).TotalMinutes >= CooldownMinutes;
    }

    private async Task ExecuteTts(POI poi)
    {
        _playbackHistory[poi.Id] = DateTime.Now; // Cập nhật lịch sử theo ID
        try
        {
            // Phát giọng nói thuyết minh
            await TextToSpeech.Default.SpeakAsync(poi.Tts, new SpeechOptions
            {
                Pitch = 1.0f,
                Volume = 1.0f
            });
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"TTS Error: {ex.Message}");
        }
    }
    public void StopEngine() => _isTracking = false;
}