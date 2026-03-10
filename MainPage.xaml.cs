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
    }
}
