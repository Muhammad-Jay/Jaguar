using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Jaguar.Core.Abstractions;

namespace Jaguar.Desktop.Models;

public partial class FlowNode : ObservableObject
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Title { get; set; }
    public NodeType Type { get; set; }

    [ObservableProperty] private double _x;
    [ObservableProperty] private double _y;

    public ObservableCollection<FlowNode> Children { get; set; } = new();
    public FlowNode? Parent { get; set; }
}

public enum NodeType { Orchestrator, Milestone, Agent, Task }