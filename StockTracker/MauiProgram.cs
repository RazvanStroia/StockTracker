using CommunityToolkit.Maui;
using MauiIcons.SegoeFluent;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StockTracker.Services;
using System.Reflection;

namespace StockTracker
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>().UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.UseMauiApp<App>().UseSegoeFluentMauiIcons();

            builder.Services.AddSingleton<StockViewModel>();
            builder.Services.AddSingleton<StockService>();

            builder.Services.AddSingleton<StockSearchViewModel>();
            builder.Services.AddTransient<StockDetailsViewModel>();

            builder.AddAppSettings();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static void AddAppSettings(this MauiAppBuilder builder)
        {
            using Stream stream = Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream("StockTracker.appsettings.json");

            if (stream != null)
            {
                IConfigurationRoot config = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();
                builder.Configuration.AddConfiguration(config);
            }
        }
        public static IServiceProvider Services { get; }
    }
}
