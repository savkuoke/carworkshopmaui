using CarWorkshopMaui.Models;
using CarWorkshopMaui.Services;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace CarWorkshopMaui.ViewModels;

public class AddReservationViewModel : BindableObject
{
    private readonly IDataService _dataService;

    public Reservation Reservation { get; set; } = new Reservation();

    public ICommand SaveCommand { get; }
    public ICommand CancelCommand { get; }

    public AddReservationViewModel(IDataService dataService)
    {
        _dataService = dataService;
        SaveCommand = new Command(async () => await SaveAsync());
        CancelCommand = new Command(async () => await Shell.Current.GoToAsync(".."));
    }

    private async System.Threading.Tasks.Task SaveAsync()
    {
        await _dataService.AddReservationAsync(Reservation);
        await Shell.Current.GoToAsync("..");
    }
}