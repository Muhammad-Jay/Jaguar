using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Jaguar.Core.Abstractions;
using Jaguar.Core.Events;
using Jaguar.Core.Models.Graph;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Services.Events.Ui;
using CognitiveState = Jaguar.Core.Models.Graph.CognitiveState;
using FlowNode = Jaguar.Core.Models.Graph.FlowNode;

namespace Jaguar.Desktop.ViewModels;

public partial class FlowNodeViewModel : ObservableObject
{
    private readonly IEventAggregator _eventAggregator;
    private readonly IAiProvider _llm; 
    public FlowNode Domain { get; }

    // UI State
    [ObservableProperty] private bool _isSelected;
    [ObservableProperty] private bool _isRunning;
    [ObservableProperty] private Point _location;
    
    public Size Size => Type switch
    {
        NodeType.Orchestrator => new Size(220, 170),
        NodeType.ProjectManager => new Size(250, 130),
        NodeType.Agent => new Size(170, 120),
        _ => new Size(250, 130)
    };
    
    public ObservableCollection<ConnectorViewModel> Inputs { get; } = new();
    public ObservableCollection<ConnectorViewModel> Outputs { get; } = new();

    public FlowNodeViewModel(FlowNode node, IEventAggregator eventAggregator, IAiProvider llm)
    {
        _eventAggregator = eventAggregator;
        _llm = llm;
        
        Domain = node;
        Location = new Point(200, 200);
        
        Inputs.Add( new ConnectorViewModel(PortDirection.Input));
        Outputs.Add(new ConnectorViewModel(PortDirection.Output));

        SubcribeToEvents();
        
        UpdateAnchors();

        PropertyChanged += OnPropertyChanged;
    }

    private void SubcribeToEvents()
{
    switch (Domain.Type)
    {
        case NodeType.Intent:
            _eventAggregator.Subscribe<TaskCreatedEvent>(OnTaskCreated);
            break;

        case NodeType.Agent: // Research node
            _eventAggregator.Subscribe<IntentNodeCompleteEvent>(OnIntentCompleted);
            break;

        case NodeType.Reasoning:
            _eventAggregator.Subscribe<ResearchNodeCompleteEvent>(OnResearchCompleted);
            break;

        case NodeType.Plan:
            _eventAggregator.Subscribe<AnalysisNodeCompleteEvent>(OnAnalysisCompleted);
            break;
    }
}


    private async Task ExecuteAsync(string message, Guid correlationId)
    {
        try
        {
            Console.WriteLine($"Message: {message}");
            Domain.State = CognitiveState.Thinking;
            IsRunning = true;
            var output = await _llm.GenerateAsync(Domain.SystemInstruction, message);

            Console.WriteLine($"Result: {output}");

            PublishResult(correlationId, output);

            Domain.State = CognitiveState.Completed;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
        finally
        {
            IsRunning = false;
        }
    }

    private void PublishResult(Guid correlationId, string output)
    {
        switch (Domain.Type)
        {
            case NodeType.Intent:
                _eventAggregator.Publish(
                    new IntentNodeCompleteEvent(output, correlationId));
                break;

            case NodeType.Agent: // Research
                _eventAggregator.Publish(
                    new ResearchNodeCompleteEvent(output, correlationId));
                break;

            case NodeType.Reasoning:
                _eventAggregator.Publish(
                    new AnalysisNodeCompleteEvent(output, correlationId));
                break;

            case NodeType.Plan:
                _eventAggregator.Publish(
                    new DecisionNodeCompletEvent(output, correlationId));
                break;
        }
    }


    private async void OnTaskCreated(TaskCreatedEvent e)
    {
        await ExecuteAsync(e.Task, e.CorrelationId);
    }
    
    private async void OnIntentCompleted(IntentNodeCompleteEvent e)
    {
        await ExecuteAsync(e.Intent, e.CorrelationId);
    }
    
    private async void OnResearchCompleted(ResearchNodeCompleteEvent e)
    {
        await ExecuteAsync(e.Result, e.CorrelationId);
    }
    
    private async void OnAnalysisCompleted(AnalysisNodeCompleteEvent e)
    {
        await ExecuteAsync(e.Analysis, e.CorrelationId);
    }
    
    private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Location))
        {
            UpdateAnchors();
        }
    }

    partial void OnLocationChanged(Point value)
    {
        UpdateAnchors();
    }

    public void UpdateAnchors()
    {
        foreach (var i in Inputs)
            i.Anchor.Update(Location, Size);

        foreach (var o in Outputs)
            o.Anchor.Update(Location, Size);
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
