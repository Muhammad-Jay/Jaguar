using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Core.Services;
using Jaguar.Desktop.Services.AppState;
using Jaguar.Desktop.ViewModels.Dialog.Contents;
using Jaguar.Desktop.ViewModels.Templates;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.ViewModels.Dialog;

public partial class DialogViewModel : ViewModelBase
{ 
    [ObservableProperty] private AppStateService? _appState;
    [ObservableProperty] private Orchestrator? _workFlowOrchestrator;

    public DialogViewModel(IServiceProvider serviceProvider)
    {
        AppState = serviceProvider.GetRequiredService<AppStateService>();
        Console.WriteLine($"Menu Init: AppState is {(AppState != null ? "Active" : "Null")}");
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