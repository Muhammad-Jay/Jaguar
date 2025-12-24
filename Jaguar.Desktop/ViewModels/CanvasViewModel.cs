using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using CommunityToolkit.Mvvm;
using Jaguar.Core.Abstractions;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Views;

namespace Jaguar.Desktop.ViewModels;

public partial class CanvasViewModel : ViewModelBase
{
    public ObservableCollection<FlowNode> Nodes { get; } = new();
    public ObservableCollection<ConnectionViewModel> Connections { get; } = new();
       
    public CanvasViewModel()
    {
        // Create some test nodes
        Nodes.Add(new FlowNode 
        { 
            Title = "Node 1", 
            Location = new Point(100, 100) 
        });
           
        Nodes.Add(new FlowNode 
        { 
            Title = "Node 2", 
            Location = new Point(400, 200) 
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