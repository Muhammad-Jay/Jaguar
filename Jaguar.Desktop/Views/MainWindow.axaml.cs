using Avalonia.Controls;
using Jaguar.Core.Services;
using Jaguar.Desktop.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        if (Program.AppHost != null)
        {
            // This gets the ViewModel and injects that orchestrator into it automatically
            DataContext = Program.AppHost.Services.GetRequiredService<MainWindowViewModel>();
        }
    }
}