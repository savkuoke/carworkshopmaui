using System.Collections.Generic;
using System.Threading.Tasks;
using CarWorkshopMaui.Models;
using System;

namespace CarWorkshopMaui.Services;

public interface IDataService
{
    Task<IEnumerable<Reservation>> GetReservationsAsync();
    Task<Reservation> AddReservationAsync(Reservation reservation);
    Task<bool> UpdateReservationAsync(Reservation reservation);
    Task<bool> DeleteReservationAsync(Guid id);
}