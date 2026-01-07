using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Jaguar.Core.Abstractions;
using Jaguar.Core.Models.Graph;
using Jaguar.Core.Models.Templates;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Services.AppState;
using Jaguar.Desktop.Services.Events.Ui;
using Jaguar.Desktop.ViewModels.Dialog.Contents;
using Jaguar.Desktop.ViewModels.Templates;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.ViewModels;

public partial class CanvasViewModel : ViewModelBase
{
    private readonly IGraphService _graph;
    private readonly IEventAggregator _event;
    private readonly IAgentTemplateRepository _agentRepository;
    private readonly FlowNodeViewModelFactory _nodeFactory;
    private readonly IServiceProvider _serviceProvider;
    [ObservableProperty] private AppStateService? _appState;

    private FlowNodeViewModel _orchetratorNode;
    public ObservableCollection<FlowNodeViewModel> Nodes { get; } = new();
    public ObservableCollection<ConnectionViewModel> Connections { get; } = new();
    public ObservableCollection<FlowNodeViewModel> SelectedNodes { get; } = new();

    [ObservableProperty] private FlowNodeViewModel? _selectedNode;
    [ObservableProperty] private FlowNodeViewModel? _addNodeParent;
    

    public CanvasViewModel(IServiceProvider serviceProvider, IGraphService graphService, IEventAggregator eventAggregator, IAgentTemplateRepository agentRepository, FlowNodeViewModelFactory flowNodeViewModelFactory)
    {
        _graph = graphService;
        _event = eventAggregator;
        _agentRepository = agentRepository;
        _nodeFactory = flowNodeViewModelFactory;
        _serviceProvider = serviceProvider;
        AppState = serviceProvider.GetRequiredService<AppStateService>();
        _serviceProvider = serviceProvider;
        
        // Initial Seed Data
        SetupInitialNodes();

        // Events
        SubscribeToEvents();
    }

    private void SetupInitialNodes()
    {
        _orchetratorNode = CreateNode(
            "Orchestrator",
            NodeType.Orchestrator,
            new Point(100, 100));

        var kernel = CreateNode(
            "Kernel Agent",
            NodeType.Agent,
            new Point(400, 100));

        Connect(
            _orchetratorNode.Outputs.First(),
            kernel.Inputs.First());
    }

    private void SubscribeToEvents()
    {
        _event.Subscribe<AddNodeEvent>(e => AddAndConnectNode(_orchetratorNode, e.Id));
    }

    private void AddAndConnectNode(FlowNodeViewModel fromNode, string id)
    {
        var template = _agentRepository.GetById(id).Result;

        if (template != null)
        {
            var pointX = fromNode.Location.X + 150;
            var pointY = fromNode.Location.Y + 150;
            
            var newNode = CreateNode(
                template.Title,
                template.Type,
                new Point(pointX, pointY));

            Connect(
                fromNode.Outputs.First(),
                newNode.Inputs.First());
        }
    }
    
    private FlowNodeViewModel CreateNode(
        string title,
        NodeType type,
        Point location)
    {
        var domain = _graph.CreateNode(title, type);

        var vm = _nodeFactory.CreateNode(domain);

        Nodes.Add(vm);
        return vm;
    }

    private void Connect(
        ConnectorViewModel from,
        ConnectorViewModel to)
    {
        _graph.Connect(from.NodeId, to.NodeId);
        
        UpdateAnchorPosition(from);
        UpdateAnchorPosition(to);

        var connection = new ConnectionViewModel(
            from.Anchor,
            to.Anchor
        );

        Connections.Add(connection);

        from.IsConnected = true;
        to.IsConnected = true;
    }


    private void UpdateAnchorPosition(ConnectorViewModel connector)
    {
        var node = Nodes.First(n => n.Domain.Id == connector.NodeId);

        // Basic layout (simple & stable)
        var x = connector.Direction == PortDirection.Output
            ? node.Location.X + 180   // right side of node
            : node.Location.X;        // left side of node

        var y = node.Location.Y + 40; // vertical center-ish

        connector.Anchor.Position = new Point(x, y);
    }
    
    [RelayCommand]
    public void ToggleAgentDialog()
    {
        if(AppState != null)
        {
            AppState.IsAgentDialogOpen = !AppState.IsAgentDialogOpen;   
        }
    }
}