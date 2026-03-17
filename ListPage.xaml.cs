using FoodStreet.Services;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace FoodStreet;

public partial class ListPage : ContentPage
{
    private List<POI> _allItems;

    public ObservableCollection<POI> Items { get; set; }

    // ✅ EVENT thay cho MessagingCenter
    public static event Action<POI> OnMoveToLocation;

    public ListPage(List<POI> poiList)
    {
        InitializeComponent();

        _allItems = poiList;
        Items = new ObservableCollection<POI>(_allItems);

        listView.ItemsSource = Items;
    }

    // 🔍 SEARCH
    private void OnSearchChanged(object sender, TextChangedEventArgs e)
    {
        var keyword = e.NewTextValue?.ToLower() ?? "";

        var filtered = _allItems
            .Where(p => p.Name.ToLower().Contains(keyword))
            .ToList();

        Items.Clear();

        foreach (var item in filtered)
        {
            Items.Add(item);
        }
    }

    // 📄 CHI TIẾT
    private async void OnDetailClicked(object sender, EventArgs e)
    {
        var btn = sender as Button;
        var poi = btn?.CommandParameter as POI;

        if (poi == null) return;
        await this.DisplayAlert(
            "Chi tiết",
            poi.Name + "\n" + poi.Description + "\n⭐ " + poi.Rating,
            "OK"
        );
    }

    // 📍 NHẢY VỀ MAP
    private async void OnMapClicked(object sender, EventArgs e)
    {
        var btn = sender as Button;
        var poi = btn?.CommandParameter as POI;

        if (poi == null) return;

        // Quay lại map
        await Navigation.PopAsync();

        // Gửi dữ liệu về MainPage
        OnMoveToLocation?.Invoke(poi);
    }
}