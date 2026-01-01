using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Jaguar.Desktop.Models;

namespace Jaguar.Desktop.Services.Workflow;

public partial class WorkflowState: ObservableObject, IWorkflowState
{
    public ObservableCollection<FlowNode> Nodes { get; } = new();
    public ObservableCollection<ConnectionViewModel> Connections { get; } = new();
    
    public WorkflowState()
    {
        
    }
}