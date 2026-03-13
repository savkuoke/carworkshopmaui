using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWorkshopMaui.Models;
using System;

namespace CarWorkshopMaui.Services;

public class InMemoryDataService : IDataService
{
    private readonly List<Reservation> _reservations = new();

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
}