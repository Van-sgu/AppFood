using FoodStreet.Models;
using FoodStreet.Services;

namespace FoodStreet.Pages
{
    public partial class DetailPoi : ContentPage
    {
        private readonly POI _poi;
        private readonly Notifications _notificationService = new Notifications();

        public DetailPoi(POI poiData)
        {
            InitializeComponent();
            _poi = poiData;

            lblTitle.Text = _poi.Name;
            lblDescription.Text = _poi.Tts;
        }
        private async void OnSpeakClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;

            try
            {
                // Vô hiệu hóa nút để tránh người dùng nhấn liên tục
                button.IsEnabled = false;
                button.Text = "⌛ Đang phát...";

                // Bật chế độ cho phép nói (vì trang chi tiết là do người dùng chủ động nhấn)
                _notificationService.Play();

                await _notificationService.SpeakAsync(_poi);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Lỗi", "Không thể phát thuyết minh: " + ex.Message, "OK");
            }
            finally
            {
                // Trả lại trạng thái ban đầu cho nút bấm
                button.IsEnabled = true;
                button.Text = "🔊 Nghe thuyết minh";
            }
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            // Quan trọng: Dừng thuyết minh ngay lập tức khi người dùng thoát trang chi tiết
            _notificationService.StopCurrentSpeech();
        }
    }
}
