using Microsoft.Maui.Maps;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace FoodStreet
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            StartTracking();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(10.7626, 106.6602), Distance.FromKilometers(1)));
        }
        async void StartTracking()
        {
            // Kiểm tra quyền truy cập vị trí
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }

            if (status == PermissionStatus.Granted)
            {
                // Đăng ký sự kiện thay đổi vị trí
                Geolocation.Default.LocationChanged += OnLocationChanged;

                // Cấu hình yêu cầu vị trí (độ chính xác và khoảng cách cập nhật)
                var request = new GeolocationListeningRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(5));
                await Geolocation.Default.StartListeningForegroundAsync(request);
            }
        }

        void OnLocationChanged(object sender, GeolocationLocationChangedEventArgs e)
        {
            // Mỗi khi vị trí thay đổi, hàm này sẽ được gọi
            var newLocation = e.Location;

            MainThread.BeginInvokeOnMainThread(() =>
            {
                // Cập nhật bản đồ di chuyển theo người dùng
                var mapSpan = Microsoft.Maui.Maps.MapSpan.FromCenterAndRadius(
                    new Location(newLocation.Latitude, newLocation.Longitude),
                    Microsoft.Maui.Maps.Distance.FromKilometers(0.5));

                map.MoveToRegion(mapSpan);

                // Hiển thị dấu chấm xanh vị trí người dùng
                map.IsShowingUser = true;
            });
        }

        // Hủy đăng ký khi thoát trang để tiết kiệm pin
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Geolocation.Default.LocationChanged -= OnLocationChanged;
            Geolocation.Default.StopListeningForeground();
        }
        private void SetupFoodlFields()
        {
            // 1. Tạo danh sách các điểm POI 
            var poiList = new List<Pin>
    {
        new Pin
        {
            Label = "Buffet 79k- Hương Việt ",
            Address = "22 Đ.Tân Quý, Tân Quý, Tân Phú, Thành phố Hồ Chí Minh, Việt Nam,
            Type = PinType.Place,
            Location = new Location(10.798538682998302, 106.61961078160493)
        },
        new Pin
        {
            Label = "LẨU 69K - Lẩu Nhà An ( CN17 )\r\n",
            Address = "12 Đ.Tân Quý, Tân Quý, Tân Phú, Thành phố Hồ Chí Minh 700000, Việt Nam",
            Type = PinType.Place,
            Location = new Location(10.7983923274548, 106.61973052485757)
        }
    };

            // 2. Thêm từng điểm vào bản đồ
            foreach (var poi in poiList)
            {
                map.Pins.Add(poi);

            }
        }

        private async void OnPoiClicked(object sender, PinClickedEventArgs e)
        {
            var pin = sender as Pin;
            if (pin != null)
            {
                await DisplayAlert("Thông tin", $"Bạn đã chọn: {pin.Label}\nĐịa chỉ: {pin.Address}", "Đóng");
            }
        }
    }
}
