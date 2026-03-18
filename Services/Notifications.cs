using FoodStreet.Models;
using FoodStreet.Data;

namespace FoodStreet.Services;

public class Notifications
{
    private int? _currentPoiId = null;
    private CancellationTokenSource? _cts;
    private bool _isSpeaking = false;
    List<POI> _poiList = new();
    DataServices _dbService = new();

    public bool IsAutoNarrateEnabled { get; private set; } = false;
    public Notifications(DataServices dbService)
    {
        _dbService = dbService;
    }
    public async Task LoadPoisFromSqlAsync()
    {
        try
        {
            _poiList = await _dbService.GetItemsAsync();
        }
        catch { /* Log error */ }
    }
    public void Play()
    {
        IsAutoNarrateEnabled = true;
    }
    public void Pause()
    {
        IsAutoNarrateEnabled = false;
        StopCurrentSpeech();
    }
    public async Task SpeakAsync(POI poi)
    {
        if (!IsAutoNarrateEnabled) return;
        if (_currentPoiId == poi.Id && _isSpeaking) return;
        StopCurrentSpeech();

        _cts = new CancellationTokenSource();
        _currentPoiId = poi.Id;
        _isSpeaking = true;

        try

        {
            await TextToSpeech.Default.SpeakAsync(poi.Tts, new() { Pitch = 1.0f, Volume = 1.0f }, _cts.Token);
        }
        catch (OperationCanceledException) { }
        finally 
        { 
            _isSpeaking = false; 
        }
    }

    public void StopCurrentSpeech()
    {
        if (_cts != null && !_cts.IsCancellationRequested)
        {
            _cts.Cancel();
            _cts.Dispose();
            _cts = null;
        }
        _isSpeaking = false;
    }
}