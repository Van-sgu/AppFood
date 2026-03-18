namespace FoodStreet
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Pages.Map), typeof(Pages.Map));
            Routing.RegisterRoute(nameof(Pages.MainPage), typeof(Pages.MainPage));
            Routing.RegisterRoute(nameof(Pages.SettingsPage), typeof(Pages.SettingsPage));
        }
    }
}
