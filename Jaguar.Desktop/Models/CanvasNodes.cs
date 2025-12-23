using System;
using System.Collections.Generic;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using Jaguar.Core.Abstractions;

namespace Jaguar.Desktop.Models;

public partial class FlowNode : ObservableObject
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Title { get; set; }
    public NodeType Type { get; set; }

    [ObservableProperty] private Point _location;

    public List<FlowNode> Children { get; set; } = new();
    public FlowNode? Parent { get; set; }
    
    [ObservableProperty] private Point _input;

    [ObservableProperty] private Point _output;
    
    [ObservableProperty] private string _status = "Idle"; // "Working", "Completed", "Failed"
    public string Description { get; set; }
}