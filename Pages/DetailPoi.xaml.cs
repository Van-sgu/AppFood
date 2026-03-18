using FoodStreet.Models;
using FoodStreet.Services;

namespace FoodStreet.Pages
{
    public partial class DetailPoi : ContentPage
    {
        private readonly POI _poi;
        Notifications _notifyService;

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
                _notifyService.Play();

                await _notifyService.SpeakAsync(_poi);
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
            _notifyService.StopCurrentSpeech();
        }
    }
}
