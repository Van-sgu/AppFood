using FoodStreet.Data;
using FoodStreet.Models;
using FoodStreet.Services;

//trang chủ chính - hiển thị khi người dùng mở app lên

namespace FoodStreet.Pages;

public partial class MainPage : ContentPage
{
    private readonly DataServices _dbService;
    public MainPage(DataServices dbService)
    {
        InitializeComponent();
        _dbService = dbService;
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
}