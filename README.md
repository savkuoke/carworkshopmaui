CarWorkshopMaui - simple .NET MAUI app for car repair reservations

Prerequisites:
- .NET 8 SDK with MAUI workloads installed
- Visual Studio 2022/2023 or `dotnet` with MAUI support

To build:

```bash
cd CarWorkshopMaui
dotnet build
```

To run on a specific target (example Android):

```bash
dotnet build -t:Run -f net8.0-android
```