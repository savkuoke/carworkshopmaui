# CarWorkshopMaui

CarWorkshopMaui - simple .NET MAUI app for car repair reservations

## Prerequisites

- .NET 8 SDK with MAUI workloads installed
- Visual Studio 2022/2023 or `dotnet` with MAUI support

## Build

```bash
cd CarWorkshopMaui
dotnet build
```

## Run (example Mac Catalyst)

```bash
dotnet build -t:Run -f net8.0-maccatalyst
```

## Modules

This project is organized into the following top-level modules/folders (where most application code lives):

- `Models/` — domain models such as `Reservation` and `Vehicle`.
- `Services/` — application services and data stores (currently `InMemoryDataService` implementing `IDataService`).
- `ViewModels/` — MVVM view models (e.g. `MainViewModel`, `AddReservationViewModel`, `VehiclesViewModel`).
- `Views/` — XAML pages and code-behind for UI (`MainPage.xaml`, `AddReservationPage.xaml`, `VehiclesPage.xaml`, etc.).
- `Platforms/` — platform entry points and platform-specific code (MacCatalyst `Program.cs` / `AppDelegate.cs`).
- `Resources/` — images, styles and other static resources (e.g. `Resources/Images/car.svg`).
- `Tests/` — unit tests (xUnit) for service-layer logic (`Tests/CarWorkshopMaui.Tests`).

## Assistant help

If you'd like the assistant to remind you what this project is about, you can ask:

> remind me what this project is about

I'll reply with a concise summary of the project's purpose, structure, and recent changes.
