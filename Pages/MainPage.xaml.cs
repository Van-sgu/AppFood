using FoodStreet.Data;
using FoodStreet.Models;
using FoodStreet.Services;

//trang chủ chính - hiển thị khi người dùng mở app lên

namespace FoodStreet.Pages;

public partial class MainPage : ContentPage
{
    private readonly DataServices _dbService;
    private readonly Notifications _notifyService;
    public MainPage(DataServices dbService)
    {
        InitializeComponent();
        _dbService = dbService;
        _notifyService = new Notifications(_dbService);
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        try
        {
            var items = await _dbService.GetItemsAsync();

            if (items != null)
            {
                MyCollectionView.ItemsSource = items;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Lỗi nạp dữ liệu: {ex.Message}");
        }
    }
    private async void DetailClicked(object sender, EventArgs e)
    {
        var btn = sender as Button;
        var poi = btn?.BindingContext as POI;

        if (poi != null)
        {
            await Navigation.PushAsync(new DetailPoi(poi));
        }
    }
    private async void NarrateClicked(object sender, EventArgs e)
    {
        var btn = sender as Button;
        var poi = btn?.BindingContext as POI;

        if (poi != null)
        {
            _notifyService.Play();

            await Shell.Current.GoToAsync("///map");
            await Task.Delay(200);
            var mapPage = Shell.Current.CurrentPage as FoodStreet.Pages.Map;
            if (mapPage != null)
            {
                mapPage.MoveToLocation(poi.Latitude, poi.Longitude);
                await _notifyService.SpeakAsync(poi);
            }
        }
    }
    private async void OpenMap(object sender, EventArgs e)
    {
        var label = sender as Label;
        var poi = label?.BindingContext as POI;
        if (poi != null)
        {
            await Shell.Current.GoToAsync("///map");
            await Task.Delay(200);
            var mapPage = Shell.Current.CurrentPage as FoodStreet.Pages.Map;
            if (mapPage != null)
            {
                mapPage.MoveToLocation(poi.Latitude, poi.Longitude);
            }
        }
    }
}