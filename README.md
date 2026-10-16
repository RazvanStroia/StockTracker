# StockTracker

A minimalistic cross-platform stock tracking app built with .NET MAUI. It uses the [Marketstack](https://marketstack.com) API for stock data and [Logo.dev](https://www.logo.dev) for company logos.

## Really Quick Preface

I created this project as a way to learn the stack, if anybody happens to stumble across this repo just know that this app is not made to be used in a production environment, its just for me to track my progress in learning MAUI.
Also, if you use the marketstack api on a free plan, make sure to limit the api requests with the api limit string in appsettings, because the way i coded the service, it uses 1 api call/every stock in the mainpage list.

## Features

- **Main page:** a list of stocks, each with its logo. Tap a stock to open its details.
- **Details page:** more information about a stock, such as open price, close price and trading volume.
- **Search page:** search for a stock or symbol. Results are shown as a list you can tap to see details.

## Tech Stack

- C# / .NET 10 / .NET MAUI
- MVVM architecture
- Marketstack API (stock data)
- Logo.dev (stock ticker logos)

## Architecture

- **Views:** `MainPage`, `StockDetailsPage` and `StockSearchPage` (XAML)
- **ViewModels:** one per page (`MainPageViewModel`, `StockDetailsPageViewModel`, `StockSearchPageViewModel`) and `BaseViewModel` which just contains a few properties that the other viewmodels inherit, an isbusy property for the activity indicator and a title property for the page.
- **Models:** classes that mirror the JSON returned by the Marketstack API
- **Service:** a single service that handles all API calls (`StockService`). The view models use it to fetch and process data before passing it to the views.

## Supported Platforms

- Android
- iOS (might not work, have not tested)
- macOS (Mac Catalyst) (might not work, have not tested)
- Windows

iOS and Mac Catalyst builds require macOS. Windows builds require Windows (duh).

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download) with the MAUI workload:

```bash
  dotnet workload install maui
```

- Visual Studio 2022 or newer with the ".NET Multi-platform App UI development" workload (or VS Code with the .NET MAUI extension)
- A [Marketstack](https://marketstack.com) API key. The free plan is limited to 100 API calls per month.
- A [Logo.dev](https://www.logo.dev) publishable key

## Configuration

API keys are kept in an `appsettings.json` file, which is git-ignored and not included in the repository. Create it yourself in the `StockTracker/` project folder:

```json
{
  "STOCKICONS_PK": "Logo.dev Publishable Key",
  "STOCKTRACKER_API_LIMIT": "1", (Basically the api call limit for the app, which i used for testing to not use too many api calls, you could limit it to 50 if you want.)
  "STOCKTRAKCER_API_KEY": "MarketStack API Key"
}
```

The app won't load stock data or logos without these keys.

## Getting Started

1. Clone the repository:

```bash
   git clone https://github.com/RazvanStroia/StockTracker.git
   cd StockTracker
```

2. Create `appsettings.json` as described above.

3. Open `StockTracker.slnx` in Visual Studio, select a target (Android emulator, Windows Machine, etc.) and press **F5**.

   Or run from the command line, for example for Android:

```bash
   dotnet build StockTracker/StockTracker.csproj -f net10.0-android
```

## Project Structure

```
StockTracker/
├── StockTracker/              # MAUI app
│   ├── Properties/       # It just contains the launchsettings.json file
│   ├── Converter/       # Contains a converter which handles the empty text in the searchbar, just clears the searchpage stock list.
│   ├── Model/       # Contains all the model objects.
│   ├── Platforms/       # Contains all the platform specific resources and app startup delegates.
│   ├── Resources/       # Contains all the basic resources for a .NET MAUI app.
│   ├── Services/       # Contains the stockservice class.
│   ├── View/       # Contains all the app pages.
│   ├── ViewModel/       # Contains all the view models.
│   └── App.xaml and the code behind      # The xaml contains style rules used throughout the app.
│   └── AppShell.xaml and the code behind # The xaml contains style rules for the tab bar and the code behind contains the routing for the pages.
│   └── GlobalUsings.cs       # Global usings for the app, to make the code more readable.
│   └── MauiProgram.cs    # Contains the app builder, and the dependency injections for the app.
└── StockTracker.slnx          # Solution file
```
