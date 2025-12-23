using System.Collections.Generic;
using System.Drawing;

namespace Jaguar.Core.Abstractions;

public interface IDraggableNode
{
    string Id { get; }
    string Title { get; set; }
    NodeType Type { get; }
    
    // Spatial coordinates for the Cyberpunk Canvas
    Point Location { get; set; }

    // Hierarchy management
    IDraggableNode? Parent { get; set; }
    
    List<IDraggableNode> Children { get; }
}

public enum NodeType
{
    Orchestrator, Milestone, Agent, Task   
}