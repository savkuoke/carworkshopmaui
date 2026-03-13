using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using CarWorkshopMaui.Services;
using CarWorkshopMaui.ViewModels;
using CarWorkshopMaui.Views;

namespace CarWorkshopMaui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        // register services and viewmodels
        builder.Services.AddSingleton<IDataService, InMemoryDataService>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddTransient<AddReservationViewModel>();
        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<AddReservationPage>();

        return builder.Build();
    }
}