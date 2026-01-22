using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Jaguar.Core.Services;
using Jaguar.Desktop.ViewModels;
using Material.Icons;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        this.WindowState = WindowState.Maximized;
        this.TransparencyLevelHint = new[] { WindowTransparencyLevel.AcrylicBlur, WindowTransparencyLevel.None };
        this.CornerRadius = new CornerRadius(this.WindowState == WindowState.Maximized ? 0 : 20);
        this.ClipToBounds = true;
        
        if (Program.AppHost != null)
        {
            // This gets the ViewModel and injects that orchestrator into it automatically
            DataContext = Program.AppHost.Services.GetRequiredService<MainWindowViewModel>();
        }
    }
    
    private void OnTitleBarPointerPressed(object sender, PointerPressedEventArgs e)
    {
        this.BeginMoveDrag(e);
    }

    private void OnMinimizeClick(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
    
    private void OnCloseClick(object sender, RoutedEventArgs e) => Close();
    
    private void OnMaximizeClick(object sender, RoutedEventArgs e)
    {
        if (this.WindowState == WindowState.Maximized)
        {
            this.WindowState = WindowState.Normal;
            MaximizeIcon.Kind = MaterialIconKind.WindowMaximize;
        }
        else
        {
            this.WindowState = WindowState.Maximized;
            MaximizeIcon.Kind = MaterialIconKind.WindowRestore;
        }
    }
    
    private void OnTitleBarDoubleTapped(object sender, TappedEventArgs e)
    {
        OnMaximizeClick(sender, e);
    }
}