namespace FoodStreet.Pages;

public partial class SettingsPage : ContentPage
{
    double volume = 100;
    double speed = 1.0;

    public SettingsPage()
    {
        InitializeComponent();
    }

    // 🔊 ÂM LƯỢNG
    private void OnVolumeChanged(object sender, ValueChangedEventArgs e)
    {
        volume = e.NewValue;
        if (volumeLabel != null)
            volumeLabel.Text = $"Âm lượng: {(int)volume}%";
    }

    // 🗣️ TỐC ĐỘ
    private void OnSpeedChanged(object sender, ValueChangedEventArgs e)
    {
        speed = e.NewValue;
        if (speedLabel != null)
            speedLabel.Text = $"Tốc độ giọng nói: {speed:0.0}x";
    }

    // 🌐 NGÔN NGỮ
    private async void OnLanguageClicked(object sender, EventArgs e)
    {
        string result = await DisplayActionSheet(
            "Chọn ngôn ngữ",
            "Hủy",
            null,
            "Tiếng Việt",
            "English"
        );

        if (result != "Hủy" && result != null)
        {
            languageLabel.Text = result;
        }
    }

    // 🔄 RESET
    private void OnResetClicked(object sender, EventArgs e)
    {
        volume = 100;
        speed = 1.0;

        volumeLabel.Text = "Âm lượng: 100%";
        speedLabel.Text = "Tốc độ giọng nói: 1.0x";

        gpsSwitch.IsToggled = false;
        languageLabel.Text = "Tiếng Việt";
    }
}