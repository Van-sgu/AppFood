using Microsoft.Extensions.DependencyInjection;

namespace FoodStreet
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}