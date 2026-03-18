using FoodStreet.Data;
using FoodStreet.Pages;
using FoodStreet.Services;
using Microsoft.Extensions.Logging;

namespace FoodStreet;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiMaps();

        builder
            .UseMauiApp<App>()
            .UseMauiMaps()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<Pages.MainPage>();
        builder.Services.AddSingleton<DataServices>();
        builder.Services.AddSingleton<Services.LocationService>();
        builder.Services.AddSingleton<Services.GeofenceService>();
        builder.Services.AddSingleton<Notifications>();
        builder.Services.AddSingleton<AutoNarrationEngine>();

        builder.Services.AddTransient<Pages.Map>();
        builder.Services.AddTransient<MainPage>();
        return builder.Build();
    }
}