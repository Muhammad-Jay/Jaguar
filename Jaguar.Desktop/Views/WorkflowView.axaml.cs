using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Jaguar.Core.Services;
using Jaguar.Desktop.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.Views;

public partial class WorkflowView : UserControl
{
    public WorkflowView()
    {
        InitializeComponent();
        if (Program.AppHost != null)
        {
            // This gets the ViewModel and injects that orchestrator into it automatically
            DataContext = Program.AppHost.Services.GetRequiredService<WorkflowViewModel>();
        }
    }
}