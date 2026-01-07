using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.ViewModels;

namespace Jaguar.Desktop.Services.Workflow;

public partial class WorkflowState: ObservableObject, IWorkflowState
{
    public ObservableCollection<FlowNodeViewModel> Nodes { get; } = new();
    public ObservableCollection<ConnectionViewModel> Connections { get; } = new();
    
    public WorkflowState()
    {
        
    }
}