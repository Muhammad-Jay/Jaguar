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

    private FlowNodeViewModel? _orchetratorNode;
    public ObservableCollection<FlowNodeViewModel> Nodes { get; } = new();
    public ObservableCollection<NodeOverlayViewModel> NodeOverlays { get; } = new();
    public ObservableCollection<ConnectionViewModel> Connections { get; } = new();
    public ObservableCollection<FlowNodeViewModel> SelectedNodes { get; } = new();

    [ObservableProperty] private FlowNodeViewModel? _selectedNode;
    [ObservableProperty] private FlowNodeViewModel? _addNodeParent;


    public CanvasViewModel(IServiceProvider serviceProvider, IGraphService graphService,
        IEventAggregator eventAggregator, IAgentTemplateRepository agentRepository,
        FlowNodeViewModelFactory flowNodeViewModelFactory)
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

        Console.WriteLine(Nodes.Count);
    }

    private void SetupInitialNodes()
    {
        _orchetratorNode = CreateNode(
            "Orchestrator",
            NodeType.Orchestrator,
            new Point(200, 200));

        var kernel = CreateNode(
            "Kernel Agent",
            NodeType.ProjectManager,
            new Point(400, 300));

        var from = _orchetratorNode.Outputs.FirstOrDefault();
        var to = kernel.Inputs.FirstOrDefault();

        if (from == null || to == null) return;

        Connect(
            from, to
        );
    }

    private void SubscribeToEvents()
    {
        _event.Subscribe<AddNodeEvent>(e => AddAndConnectNode(_orchetratorNode!, e.Id));
    }

    private void AddAndConnectNode(FlowNodeViewModel fromNode, string id)
    {
        var template = _agentRepository.GetById(id).Result;

        if (template != null)
        {
            var pointX = fromNode.Location.X + 400;
            var pointY = fromNode.Location.Y + 550;

            var newNode = CreateNode(
                template.Title,
                template.Type,
                new Point(pointX, pointY));

            newNode.UpdateAnchors();
            fromNode.UpdateAnchors();

            var from = fromNode.Outputs.FirstOrDefault();
            var to = newNode.Inputs.FirstOrDefault();

            if (from == null || to == null) return;

            Connect(from, to);

            // Final UI push
            OnPropertyChanged(nameof(Connections));
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
        // _graph.Connect(from.Anchor.Domain.Id, to.Anchor.Node.Domain.Id);

        var connection = new ConnectionViewModel(
            from.Anchor,
            to.Anchor
        );

        Connections.Add(connection);

        from.IsConnected = true;
        to.IsConnected = true;
    }

    public void SetSelection(FlowNodeViewModel node, bool isMultiple)
    {
        if (!isMultiple)
        {
            // Clear previous selection
            foreach (var n in SelectedNodes) n.IsSelected = false;
            SelectedNodes.Clear();
        }

        if (!SelectedNodes.Contains(node))
        {
            node.IsSelected = true;
            SelectedNodes.Add(node);
        }
    }

    public void SyncOverlays()
    {
        NodeOverlays.Clear();

        foreach (var node in SelectedNodes)
        {
            NodeOverlays.Add(new NodeOverlayViewModel(node));
        }
    }


    [RelayCommand]
    public void ToggleAgentDialog()
    {
        if (AppState != null)
        {
            AppState.IsAgentDialogOpen = !AppState.IsAgentDialogOpen;
        }
    }

    [RelayCommand]
    public void OpenOrchestratorDialog()
    { 
        AppState?.OpenOrchestratorDialog();
    }
}