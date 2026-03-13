using System;

namespace CarWorkshopMaui.Models;

public class Reservation
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CustomerName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Vehicle { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.Now;
    public string Notes { get; set; } = string.Empty;
    public bool IsCompleted { get; set; } = false;
}