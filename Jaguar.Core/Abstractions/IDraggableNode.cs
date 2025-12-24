using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Jaguar.Core.Abstractions;

public partial class DraggableNode: ObservableObject
{
    string Id { get; }
    string Title { get; set; }
    INodeType Type { get; }
    
    // Spatial coordinates for the Cyberpunk Canvas
   [ObservableProperty] private double _x;
   [ObservableProperty] private double _y;

   public ObservableCollection<DraggableNode> Children { get; set; } = new();
   public DraggableNode? Parent { get; set; }
}

public enum INodeType
{
    Orchestrator, Milestone, Agent, Task   
}