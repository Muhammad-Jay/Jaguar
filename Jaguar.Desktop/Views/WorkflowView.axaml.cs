using Avalonia.Controls;
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
            DataContext = Program.AppHost.Services.GetRequiredService<WorkflowViewModel>();
        }
    }
}