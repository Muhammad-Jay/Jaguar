using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Core.Abstractions;
using Jaguar.Core.Events;
using Jaguar.Desktop.Abstractions;
using Jaguar.Desktop.Services.AppState;
using Jaguar.Desktop.Services.Events.Ui;

namespace Jaguar.Desktop.ViewModels.Dialog.Contents;

public partial class OrchestratorDialogPromptViewModel : ViewModelBase
{
    private readonly IEventAggregator _eventAggregator;
    private readonly AppStateService _appState;
        
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Stats))]
    private string _prompt = string.Empty;
    
    public string Stats => $"{Prompt?.Length ?? 0} chars | ~{(Prompt?.Length ?? 0) / 4} tokens";
    public OrchestratorDialogPromptViewModel(AppStateService appState, IEventAggregator eventAggregator)
    {
        _eventAggregator = eventAggregator;
        _appState = appState;
    }
    
    [RelayCommand]
    public void ExecuteRequest()
    {
        Console.WriteLine($"Request: {Prompt}");
        _appState.RunTask(Prompt);
        _eventAggregator.Publish<TaskCreatedEvent>(new  TaskCreatedEvent(Prompt, Guid.NewGuid()));
    }
}