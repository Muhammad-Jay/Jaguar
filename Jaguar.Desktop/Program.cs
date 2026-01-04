using Avalonia;
using System;
using Jaguar.Core.Abstractions;
using Jaguar.Core.Services;
using Jaguar.Desktop.Services.AppState;
using Jaguar.Desktop.ViewModels;
using Jaguar.Desktop.ViewModels.Dialog;
using Jaguar.Desktop.ViewModels.Dialog.Contents;
using Jaguar.Desktop.ViewModels.MenuItemViewModel;
using Jaguar.Desktop.ViewModels.Menus;
using Jaguar.Desktop.ViewModels.Panel;
using Jaguar.Desktop.ViewModels.Templates;
using Jaguar.Desktop.Views;
using Jaguar.LLM.Services;
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
            AppHost = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.Configure<Jaguar.Core.Models.GeminiConfig>(
                        context.Configuration.GetSection("GeminiConfig"));

                    // --- CORE SERVICES ---
                    services.AddSingleton<AppStateService>();
                    services.AddTransient<IAiProvider, LlmProvider>();
                    services.AddSingleton<Orchestrator>();
                    
                    // --- VIEW MODELS ---
                    services.AddSingleton<CanvasViewModel>();
                    
                    services.AddTransient<WorkflowViewModel>();

                    services.AddTransient<MainWindowViewModel>();

                    // --- WINDOWS ---
                    services.AddSingleton<MainWindow>();
                    
                    // --- Additional View Models ---
                    services.AddTransient<TopBarMenuViewModel>();
                    services.AddTransient<BottomBarMenuViewModel>();
                    services.AddTransient<LeftBarMenuViewModel>();
                    services.AddTransient<RightBarMenuViewModel>();
                    services.AddTransient<AgentTemplatesViewModel>();
                    services.AddTransient<OrchestratorDialogPromptViewModel>();
                    services.AddTransient<SettingsViewModel>();
                    services.AddTransient<WorkflowSidebarPanelViewModel>();
                    services.AddTransient<DialogViewModel>();
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
            .With(new X11PlatformOptions 
            { 
                EnableMultiTouch = true,
                RenderingMode = new[] { X11RenderingMode.Glx, X11RenderingMode.Software }
            })
            .WithInterFont()
            .LogToTrace(Avalonia.Logging.LogEventLevel.Debug);
}
