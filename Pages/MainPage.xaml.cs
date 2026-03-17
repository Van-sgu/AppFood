using FoodStreet.Models;
using FoodStreet.Services;

using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

//trang chủ chính - hiển thị khi người dùng mở app lên

namespace FoodStreet;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //Bắt đầu nghe vị trí khi trang xuất hiện
        var vinhkhanh = new Location(10.7765, 106.6675);
        map.MoveToRegion(MapSpan.FromCenterAndRadius(vinhkhanh, Distance.FromKilometers(0.5)));
    }
    //Bấm vào quán -> mở app


}