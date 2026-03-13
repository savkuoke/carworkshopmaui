using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using CarWorkshopMaui.Services;
using CarWorkshopMaui.Models;

namespace CarWorkshopMaui.Tests;

public class InMemoryDataServiceTests
{
    [Fact]
    public async Task GetVehiclesAsync_ReturnsSeededVehicles()
    {
        var svc = new InMemoryDataService();
        var vehicles = (await svc.GetVehiclesAsync()).ToList();
        Assert.NotNull(vehicles);
        Assert.True(vehicles.Count >= 2, "Seeded vehicles should be present");
    }

    [Fact]
    public async Task AddVehicleAsync_AddsVehicleAndAssignsId()
    {
        var svc = new InMemoryDataService();
        var v = new Vehicle { Make = "Ford", Model = "Focus", LicensePlate = "NEW-1", Year = 2015 };
        var added = await svc.AddVehicleAsync(v);
        Assert.NotEqual(Guid.Empty, added.Id);
        var all = (await svc.GetVehiclesAsync()).ToList();
        Assert.Contains(all, x => x.Id == added.Id && x.LicensePlate == "NEW-1");
    }

    [Fact]
    public async Task DeleteVehicleAsync_RemovesVehicle()
    {
        var svc = new InMemoryDataService();
        var v = new Vehicle { Make = "Test", Model = "T", LicensePlate = "DEL-1", Year = 2000 };
        var added = await svc.AddVehicleAsync(v);
        var ok = await svc.DeleteVehicleAsync(added.Id);
        Assert.True(ok);
        var all = (await svc.GetVehiclesAsync()).ToList();
        Assert.DoesNotContain(all, x => x.Id == added.Id);
    }
}
