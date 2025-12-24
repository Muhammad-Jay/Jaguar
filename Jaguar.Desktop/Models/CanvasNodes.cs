using System;
using System.Collections.ObjectModel;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using Jaguar.Core.Abstractions;
using Jaguar.Desktop.Views;

namespace Jaguar.Desktop.Models;

public partial class FlowNode : ObservableObject
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Title { get; set; }
    public NodeType Type { get; set; }

    [ObservableProperty] private Point _location;

    public ObservableCollection<ConnectorViewModel> Input { get; } = new();
    public ObservableCollection<ConnectorViewModel> Output { get; } = new();
    public ObservableCollection<FlowNode> Children { get; set; } = new();
    public FlowNode? Parent { get; set; }
}

public enum NodeType { Orchestrator, Milestone, Agent, Task }