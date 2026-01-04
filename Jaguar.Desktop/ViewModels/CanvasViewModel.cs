using System;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Services.AppState;
using Jaguar.Desktop.ViewModels.Dialog.Contents;
using Jaguar.Desktop.ViewModels.Templates;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.ViewModels;

public partial class CanvasViewModel : ViewModelBase,
    IRecipient<RequestDialogMessage>,
    IRecipient<RequestDeleteNodeMessage>,
    IRecipient<RequestOpenPromptDialog>,
    IRecipient<RequestAddNodeMessage>
{
    private readonly IServiceProvider _serviceProvider;
    [ObservableProperty] private AppStateService? _appState;

    public ObservableCollection<FlowNode> Nodes { get; } = new();
    public ObservableCollection<ConnectionViewModel> Connections { get; } = new();
    public ObservableCollection<FlowNode> SelectedNodes { get; } = new();

    [ObservableProperty] private FlowNode? _selectedNode;
    [ObservableProperty] private FlowNode? _addNodeParent;
    

    public CanvasViewModel(IServiceProvider serviceProvider)
    {
        
        AppState = serviceProvider.GetRequiredService<AppStateService>();
        _serviceProvider = serviceProvider;
        
        WeakReferenceMessenger.Default.RegisterAll(this);
        // Initial Seed Data
        SetupInitialNodes();
    }

    private void SetupInitialNodes()
    {
        var orches = new FlowNode
        {
            Title = "Orchestrator",
            Location = new Point(400, 400),
            Type = NodeType.Orchestrator,
        };

        var output = new ConnectorViewModel(orches, "Output");
        orches.Connectors.Add(output);

        var kernel = new FlowNode
        {
            Title = "Kernel Agent",
            Location = new Point(100, 200),
            Type = NodeType.Agent,
        };
        var input = new ConnectorViewModel(kernel, "Input");
        kernel.Connectors.Add(input);

        Nodes.Add(orches);
        Nodes.Add(kernel);

        var connection = new ConnectionViewModel(output.Anchor, input.Anchor);
        Connections.Add(connection);

        output.IsConnected = true;
        input.IsConnected = true;
    }



    [RelayCommand]
    public void AddNodeAtLocation(FlowNode node)
    {
        Dispatcher.UIThread.Post(() =>
        {
            var newNode = new FlowNode
            {
                Title = "New Agent",
                Location = node.Location,
                Type = node.Type,
            };
            Nodes.Add(newNode);
        });
    }
    
    public void Receive(RequestDialogMessage message)
    {
        if (AppState != null)
        {
            AddNodeParent = message.ParentNode;
            AppState.IsAgentDialogOpen = true;
            AppState.CurrentDialogView = _serviceProvider.GetRequiredService<AgentTemplatesViewModel>();
        }

        Console.WriteLine(AddNodeParent?.Type);
    }
    
    public void Receive(RequestAddNodeMessage message)
    {
        if (AppState != null && AddNodeParent != null)
        {
            Dispatcher.UIThread.Post(() =>
            {
                var newNode = new FlowNode
                {
                    Title = message.NodeToAdd.Title,
                    Location = AddNodeParent.Location,
                    Type = message.NodeToAdd.Type,
                };
                Nodes.Add(newNode);
            });
        }
        else
        {
            Dispatcher.UIThread.Post(() =>
            {
                var newNode = new FlowNode
                {
                    Title = message.NodeToAdd.Title,
                    Location = message.NodeToAdd.Location,
                    Type = message.NodeToAdd.Type,
                };
                Nodes.Add(newNode);
            });
        }
    }
    
    public void Receive(RequestDeleteNodeMessage message)
    {
        Nodes.Remove(message.NodeToDelete);
    }

    public void Receive(RequestOpenPromptDialog message)
    {
        if (AppState != null)
        {
            AppState.IsAgentDialogOpen = true;
            AppState.CurrentDialogView = _serviceProvider.GetRequiredService<OrchestratorDialogPromptViewModel>();
        }
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