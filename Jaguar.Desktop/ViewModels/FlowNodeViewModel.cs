using System.Collections.ObjectModel;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Jaguar.Core.Abstractions;
using Jaguar.Core.Models.Graph;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Services.Events.Ui;
using CognitiveState = Jaguar.Core.Models.Graph.CognitiveState;
using FlowNode = Jaguar.Core.Models.Graph.FlowNode;

namespace Jaguar.Desktop.ViewModels;

public partial class FlowNodeViewModel : ObservableObject
{
    private readonly IEventAggregator _eventAggregator;
    public FlowNode Domain { get; }

    // UI State
    [ObservableProperty] private bool _isSelected;
    [ObservableProperty] private Point _location;
    
    public ObservableCollection<ConnectorViewModel> Inputs { get; } = new();
    public ObservableCollection<ConnectorViewModel> Outputs { get; } = new();

    public FlowNodeViewModel(FlowNode node, IEventAggregator eventAggregator)
    {
        _eventAggregator = eventAggregator;
        
        Domain = node;
        Location = new Point(200, 200);
        
        Inputs.Add(new ConnectorViewModel(node.Id, "In", PortDirection.Input));
        Outputs.Add(new ConnectorViewModel(node.Id, "Out", PortDirection.Output));
    }

    // Bindable Projections
    public string Title => Domain.Title;
    public string Description => Domain.Description;
    public NodeType Type => Domain.Type;

    public CognitiveState State => Domain.State;
    public double Confidence => Domain.Confidence;

    // Commands
    [RelayCommand]
    private void OpenAgentTemplate() => _eventAggregator.Publish(new OpenAgentTemplateDialogEvent());

    [RelayCommand]
    private void DeleteSelf() => _eventAggregator.Publish(new DeleteNodeEvent(this.Domain.Id));
}