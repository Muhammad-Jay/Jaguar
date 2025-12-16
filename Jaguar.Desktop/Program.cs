using Avalonia;
using System;
using Jaguar.Desktop.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Jaguar.Desktop;

class Program
{
    public static IHost? AppHost { get; private set; }
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        try
        {
            // Create the Generic Host
            AppHost = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<MainWindowViewModel>(); 
                    
                    services.AddSingleton<MainWindow>();

                })
                .Build();

            // 2. Build and Run Avalonia
            BuildAvaloniaApp()
                .StartWithClassicDesktopLifetime(args);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during startup: {ex.Message}");
        }
    }
    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace(Avalonia.Logging.LogEventLevel.Debug);
}
