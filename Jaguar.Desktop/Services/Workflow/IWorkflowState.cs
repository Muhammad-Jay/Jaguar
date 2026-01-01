using System.Collections.ObjectModel;
using Jaguar.Desktop.Models;

namespace Jaguar.Desktop.Services.Workflow;

public interface IWorkflowState
{
    public ObservableCollection<FlowNode> Nodes { get; }
    public ObservableCollection<ConnectionViewModel> Connections { get; }
}