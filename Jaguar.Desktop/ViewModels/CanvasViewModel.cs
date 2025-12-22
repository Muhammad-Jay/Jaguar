using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using Jaguar.Desktop.Models;

namespace Jaguar.Desktop.ViewModels;

public partial class CanvasViewModel: ViewModelBase
{
    [ObservableProperty] private FlowNode _rootNode;
    [ObservableProperty] private FlowNode _currentScope;

    public CanvasViewModel()
    {
        RootNode = new FlowNode { Title = "Jaguar PM", Type = NodeType.Orchestrator, Children = new ObservableCollection<FlowNode>(){new FlowNode { Title = "test", Type = NodeType.Agent }}};
        CurrentScope = RootNode;
    }

    public void NavigateDown(FlowNode node)
    {
        if (node.Children.Any())
        {
            CurrentScope = node;
        }
    }

    public void NavigateUp()
    {
        if (CurrentScope.Parent != null)
        {
            CurrentScope = CurrentScope.Parent;
        }
    }
    
    
}