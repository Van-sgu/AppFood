using FoodStreet.Data;
using FoodStreet.Pages;

using System.Collections.ObjectModel;

namespace FoodStreet.Models
{
    public class MainPageModel
    {
        public ObservableCollection<POI> Restaurants { get; set; } = new ObservableCollection<POI>();
        private readonly DataServices dbService = new DataServices();

        public MainPageModel(DataServices dbService)
        {
            dbService = dbService;
        }
    public async Task Loadmap()
        {
            var data = await dbService.GetItemsAsync();
            // Xóa dữ liệu cũ trước khi nạp mới để tránh trùng lặp
            Restaurants.Clear();
            foreach (var item in data) { 
                Restaurants.Add(item);
            }
        }
    }
}
