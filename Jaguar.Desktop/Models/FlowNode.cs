using System;
using System.Collections.ObjectModel;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Jaguar.Desktop.ViewModels;

namespace Jaguar.Desktop.Models;

public partial class FlowNode : ViewModelBase
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Title { get; set; }
    public NodeType Type { get; set; }
    public string Description { get; set; } = string.Empty;
    public string SystemInstruction { get; set; } = string.Empty;
    
    [ObservableProperty]
    private bool _isSelected;
    
    public CognitiveState? State { get; set; }
    public double? Confidence { get; set; } // 0.0 - 1.0
    public bool? IsInternal { get; set; } // Hidden from user

    [ObservableProperty] private Point _location;
    public ObservableCollection<ConnectorViewModel> Connectors { get; } = new();
    public ObservableCollection<ConnectorViewModel> Input { get; } = new();
    public ObservableCollection<ConnectorViewModel> Output { get; } = new();
    public ObservableCollection<FlowNode> Children { get; } = new();
    public FlowNode? Parent { get; set; }
    
    [RelayCommand]
    public void OpenAgentDialog()
    {
        WeakReferenceMessenger.Default.Send(new RequestDialogMessage(this));
    }

    [RelayCommand]
    public void DeleteSelf()
    {
        WeakReferenceMessenger.Default.Send(new RequestDeleteNodeMessage(this));
    }

    [RelayCommand]
    public void OpenPromptEditor()
    {
        WeakReferenceMessenger.Default.Send(new RequestOpenPromptDialog(this));
    }

    [RelayCommand]
    public void AddNode()
    {
        WeakReferenceMessenger.Default.Send(new RequestAddNodeMessage(this));
    }
}

public enum CognitiveState
{
    Pending,
    Thinking,
    Simulating,
    Executing,
    Evaluating,
    Reflecting,
    Completed,
    Failed
}


public enum NodeType
{
    // Executive Layer
    Orchestrator,        // Executive consciousness
    ProjectManager,     // Decomposes intent into structured work

    // Intent & Planning
    Intent,             // Interpreted user intent
    Goal,               // Defined success criteria
    Plan,               // Multi-step strategy

    // Reasoning Layer
    Reasoning,          // Logical / analytical thinking
    Hypothesis,         // Assumptions to be tested
    Constraint,         // Limitations & rules

    // Simulation Layer
    Simulation,         // Imagined future execution
    Scenario,           // Alternative paths
    Risk,               // Failure points

    // Execution Layer
    Agent,              // Specialist executor
    Task,               // Atomic unit of work
    Tool,               // External system / API

    // Evaluation Layer
    Evaluation,         // Checks against success criteria
    Reflection,         // Self-critique & correction
    Decision,           // Accept / Reject / Iterate

    // Memory Layer
    Memory,             // Stored experience
    Belief,             // Assumed truth
    Knowledge           // Structured facts

}