using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Core.Services;
using Jaguar.Desktop.Services.AppState;
using Jaguar.Desktop.ViewModels.Dialog.Contents;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.ViewModels.Dialog;

public partial class DialogViewModel : ViewModelBase
{ 
    [ObservableProperty] private AppStateService? _appState;
    [ObservableProperty] private Orchestrator? _workFlowOrchestrator;
    [ObservableProperty] private ViewModelBase _currentView;

    public DialogViewModel()
    {
        if (Program.AppHost != null)
        {
            AppState = Program.AppHost.Services.GetRequiredService<AppStateService>();
                
            WorkFlowOrchestrator = Program.AppHost.Services.GetRequiredService<Orchestrator>();
        }
        CurrentView = new OrchestratorDialogPromptViewModel();
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