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
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            if (Program.AppHost != null)
            {
                var mainWindow = Program.AppHost.Services.GetRequiredService<MainWindow>();
            
                mainWindow.DataContext = Program.AppHost.Services.GetRequiredService<MainWindowViewModel>();
            
                desktop.MainWindow = new MainWindow();
            }
        }

        base.OnFrameworkInitializationCompleted();
    }
}