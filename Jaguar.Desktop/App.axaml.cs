using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Jaguar.Desktop.ViewModels;
using Jaguar.Desktop.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        Console.WriteLine("--> Avalonia Framework Init Started");
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            if (Program.AppHost != null)
            {
                Console.WriteLine("--> Attempting to resolve MainWindow from DI...");
                var mainWindow = Program.AppHost.Services.GetRequiredService<MainWindow>();
                var mainVm = Program.AppHost.Services.GetRequiredService<MainWindowViewModel>();
                
                mainWindow.DataContext = mainVm;
                desktop.MainWindow = mainWindow;
            
                Console.WriteLine("--> MainWindow Resolved successfully!");
            }
        }

        base.OnFrameworkInitializationCompleted();
    }
}