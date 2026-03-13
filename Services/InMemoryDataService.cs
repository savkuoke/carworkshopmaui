using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWorkshopMaui.Models;
using System;

namespace CarWorkshopMaui.Services;

public class InMemoryDataService : IDataService
{
    private readonly List<Reservation> _reservations = new();
    private readonly List<Vehicle> _vehicles = new();

    public InMemoryDataService()
    {
        // seed with sample data
        _reservations.Add(new Reservation
        {
            CustomerName = "John Doe",
            Phone = "555-1234",
            Vehicle = "Toyota Corolla",
            Date = DateTime.Now.AddDays(2),
            Notes = "Oil change"
        });
        _reservations.Add(new Reservation
        {
            CustomerName = "Jane Smith",
            Phone = "555-5678",
            Vehicle = "Honda Civic",
            Date = DateTime.Now.AddDays(5),
            Notes = "Brake inspection"
        });

        // seed vehicles
        _vehicles.Add(new Vehicle { Id = Guid.NewGuid(), Make = "Toyota", Model = "Corolla", LicensePlate = "ABC-123", Year = 2018 });
        _vehicles.Add(new Vehicle { Id = Guid.NewGuid(), Make = "Honda", Model = "Civic", LicensePlate = "XYZ-789", Year = 2020 });
    }

    public Task<Reservation> AddReservationAsync(Reservation reservation)
    {
        reservation.Id = Guid.NewGuid();
        _reservations.Add(reservation);
        return Task.FromResult(reservation);
    }

    public Task<bool> DeleteReservationAsync(Guid id)
    {
        var r = _reservations.FirstOrDefault(x => x.Id == id);
        if (r == null) return Task.FromResult(false);
        _reservations.Remove(r);
        return Task.FromResult(true);
    }

    public Task<IEnumerable<Reservation>> GetReservationsAsync()
    {
        return Task.FromResult(_reservations.AsEnumerable());
    }

    public Task<bool> UpdateReservationAsync(Reservation reservation)
    {
        var idx = _reservations.FindIndex(x => x.Id == reservation.Id);
        if (idx == -1) return Task.FromResult(false);
        _reservations[idx] = reservation;
        return Task.FromResult(true);
    }

    // Vehicles
    public Task<IEnumerable<Vehicle>> GetVehiclesAsync()
    {
        return Task.FromResult(_vehicles.AsEnumerable());
    }

    public Task<Vehicle> AddVehicleAsync(Vehicle vehicle)
    {
        vehicle.Id = Guid.NewGuid();
        _vehicles.Add(vehicle);
        return Task.FromResult(vehicle);
    }

    public Task<bool> UpdateVehicleAsync(Vehicle vehicle)
    {
        var idx = _vehicles.FindIndex(x => x.Id == vehicle.Id);
        if (idx == -1) return Task.FromResult(false);
        _vehicles[idx] = vehicle;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteVehicleAsync(Guid id)
    {
        var v = _vehicles.FirstOrDefault(x => x.Id == id);
        if (v == null) return Task.FromResult(false);
        _vehicles.Remove(v);
        return Task.FromResult(true);
    }
}