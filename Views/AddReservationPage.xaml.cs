using Microsoft.Maui.Controls;
using CarWorkshopMaui.ViewModels;

namespace CarWorkshopMaui.Views;

public partial class AddReservationPage : ContentPage
{
    public AddReservationPage(AddReservationViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}