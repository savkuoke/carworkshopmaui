using Microsoft.Maui.Controls;

namespace CarWorkshopMaui;

public partial class App : Application
{
    public App(AppShell shell)
    {
        InitializeComponent();
        MainPage = shell;
    }
}