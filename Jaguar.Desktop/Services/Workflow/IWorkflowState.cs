using System.Collections.ObjectModel;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.ViewModels;

namespace Jaguar.Desktop.Services.Workflow;

public interface IWorkflowState
{
    public ObservableCollection<FlowNodeViewModel> Nodes { get; }
    public ObservableCollection<ConnectionViewModel> Connections { get; }
}