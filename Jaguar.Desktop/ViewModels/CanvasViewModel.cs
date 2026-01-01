using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Desktop.Models;

namespace Jaguar.Desktop.ViewModels;

public partial class CanvasViewModel : ViewModelBase
{
    public ObservableCollection<FlowNode> Nodes { get; } = new();
    public ObservableCollection<ConnectionViewModel> Connections { get; } = new();
       
    public CanvasViewModel()
    {
        var orches = new FlowNode
        {
            Title = "Node 3",
            Location = new Point(400, 400),
            Type = NodeType.Orchestrator
        };

        var output = new ConnectorViewModel(orches, "Output");
        orches.Connectors.Add(output);
        
        var Kernel = new FlowNode
        {
            Title = "Node 3",
            Location = new Point(400, 400),
            Type = NodeType.Agent
        };
        var input = new ConnectorViewModel(Kernel, "Input");
        Kernel.Connectors.Add(input);
        
        Nodes.Add(orches);
        Nodes.Add(Kernel);
        

        var connection = new ConnectionViewModel(output.Anchor, input.Anchor);
        
        Connections.Add(connection);
    }
    
    // public void CreateLink(FlowNode sourceNode, FlowNode targetNode)
    // {
    //     // Find the Output port of the source (Orchestrator)
    //     var sourcePort = sourceNode.Connectors.FirstOrDefault(c => c.Type == ConnectorType.Output);
    //
    //     // Find the Input port of the target (Agent)
    //     var targetPort = targetNode.Connectors.FirstOrDefault(c => c.Type == ConnectorType.Input);
    //
    //     if (sourcePort != null && targetPort != null)
    //     {
    //         var connection = new ConnectionViewModel
    //         {
    //             Source = sourcePort,
    //             Target = targetPort 
    //         };
    //
    //         Connections.Add(connection);
    //     }
    // }
    
    public void AddNode(FlowNode node)
    {
        Nodes.Add(new FlowNode 
        { 
            Title = node.Title, 
            Location = new Point(100, 100),
            Type = node.Type
        });
    }
        
        
        // Inside Milestone 1
    //     AddChild(milestone1, new FlowNode { Title = "Database Agent", Type = NodeType.Agent, X = 50, Y = 100 });
    //     AddChild(milestone1, new FlowNode { Title = "Auth Service", Type = NodeType.Agent, X = 250, Y = 100 });
    //
    //     // Inside Milestone 2
    //     AddChild(milestone2, new FlowNode { Title = "UI Layout", Type = NodeType.Agent, X = 50, Y = 100 });
    //     AddChild(milestone2, new FlowNode { Title = "Theme Manager", Type = NodeType.Agent, X = 250, Y = 100 });
    //
    //     // 4. Attach Milestones to Root
    //     AddChild(RootNode, milestone1);
    //     AddChild(RootNode, milestone2);
    //
    //     // 5. Initialize Scope
    //     CurrentScope = RootNode;
    // }
    //
    // // Helper to ensure Parent/Child relationship is linked both ways
    // private void AddChild(FlowNode parent, FlowNode child)
    // {
    //     child.Parent = parent; // Crucial for NavigateUp()
    //     parent.Children.Add(child);
    // }
    //
    // public void NavigateDown(FlowNode node)
    // {
    //     Console.WriteLine($"navigeting to child: {node.Title}");
    //     if (node.Children.Any())
    //     {
    //         CurrentScope = node;
    //     }
    // }
    //
    // public void NavigateUp()
    // {
    //     if (CurrentScope.Parent != null)
    //     {
    //         Console.WriteLine("Navigating to parent.");
    //         CurrentScope = CurrentScope.Parent;
    //         return;
    //     }
    //
    //     Console.WriteLine("No Parent to Navigate to.");
    // }
    
}