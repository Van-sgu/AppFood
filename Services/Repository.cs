//using FoodStreet.Models;
//using Microsoft.Maui.Devices.Sensors;

//namespace FoodStreet.Services;

//public class AutoNarrationEngine
//{
//    private readonly Repository _db;
//    private bool _isTracking = false;

//    // Lưu lịch sử để không phát lặp lại một điểm quá nhiều lần
//    private readonly Dictionary<int, DateTime> _playbackHistory = new();
//    private const double CooldownMinutes = 2; // 2 phút sau mới được phát lại cùng 1 điểm

//    public AutoNarrationEngine(Repository repository)
//    {
//        _db = repository;
//    }

//    /// <summary>
//    /// Kích hoạt hệ thống thuyết minh tự động
//    /// </summary>
//    public async Task StartEngineAsync()
//    {
//        if (_isTracking) return;

//        // 1. Khởi tạo Database thông qua Repository
//        await _db.Init();

//        // 2. Kiểm tra quyền truy cập vị trí (tương tự LocationService)
//        var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
//        if (status != PermissionStatus.Granted) return;

//        _isTracking = true;

//        // 3. Vòng lặp quét vị trí và kích hoạt điểm
//        while (_isTracking)
//        {
//            try
//            {
//                var location = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Best));

//                if (location != null)
//                {
//                    await EvaluateAndSpeak(location);
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Lỗi quét vị trí: {ex.Message}");
//            }

//            // Nghỉ 5 giây trước khi quét đợt tiếp theo để tiết kiệm pin
//            await Task.Delay(5000);
//        }
//    }

//    private async Task EvaluateAndSpeak(Location userLoc)
//    {
//        // Lấy tất cả POI từ Database
//        var allPois = await _db.GetAll();

//        // Tìm các POI mà người dùng đang đứng bên trong bán kính (Radius)
//        var candidates = allPois.Where(poi =>
//        {
//            double dist = Location.CalculateDistance(userLoc, new Location(poi.Latitude, poi.Longitude), DistanceUnits.Kilometers) * 1000;
//            return dist <= poi.Radius;
//        }).ToList();

//        if (candidates.Any())
//        {
//            // Ưu tiên theo mức độ Priority cao nhất, nếu bằng nhau thì chọn điểm gần nhất
//            var bestPoi = candidates
//                .OrderByDescending(p => p.Priority)
//                .ThenBy(p => Location.CalculateDistance(userLoc, new Location(p.Latitude, p.Longitude), DistanceUnits.Kilometers))
//                .FirstOrDefault();

//            if (bestPoi != null && ShouldPlay(bestPoi.Id))
//            {
//                await PerformSpeech(bestPoi);
//            }
//        }
//    }

//    private bool ShouldPlay(int poiId)
//    {
//        if (!_playbackHistory.ContainsKey(poiId)) return true;

//        // Kiểm tra nếu đã qua thời gian chờ (Cooldown)
//        return (DateTime.Now - _playbackHistory[poiId]).TotalMinutes >= CooldownMinutes;
//    }

//    private async Task PerformSpeech(Poi poi)
//    {
//        try
//        {
//            // Cập nhật thời điểm phát cuối cùng
//            _playbackHistory[poiId] = DateTime.Now;

//            // Sử dụng TextToSpeech để đọc nội dung
//            await TextToSpeech.Default.SpeakAsync(poi.TtsScript);

//            Console.WriteLine($"Đã phát thuyết minh cho: {poi.Name}");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Lỗi TTS: {ex.Message}");
//        }
//    }

//    public void StopEngine()
//    {
//        _isTracking = false;
//    }
//}