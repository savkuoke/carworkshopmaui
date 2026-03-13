using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CarWorkshopMaui.Models;
using CarWorkshopMaui.Services;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace CarWorkshopMaui.ViewModels;

public class MainViewModel : BindableObject
{
    private readonly IDataService _dataService;

    public ObservableCollection<Reservation> Reservations { get; } = new();

    public ICommand LoadCommand { get; }
    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }

    public MainViewModel(IDataService dataService)
    {
        _dataService = dataService;
        LoadCommand = new Command(async () => await LoadAsync());
        AddCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(Views.AddReservationPage)));
        DeleteCommand = new Command<Reservation>(async (r) => await DeleteAsync(r));
    }

    public async Task LoadAsync()
    {
        Reservations.Clear();
        var items = await _dataService.GetReservationsAsync();
        foreach (var r in items)
            Reservations.Add(r);
    }

    public async Task DeleteAsync(Reservation r)
    {
        if (r == null) return;
        await _dataService.DeleteReservationAsync(r.Id);
        Reservations.Remove(r);
    }
}