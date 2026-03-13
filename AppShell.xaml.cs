using Microsoft.Maui.Controls;

namespace CarWorkshopMaui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        // Register route for AddReservationPage so Shell navigation by name works
        Routing.RegisterRoute(nameof(Views.AddReservationPage), typeof(Views.AddReservationPage));
    }
}
