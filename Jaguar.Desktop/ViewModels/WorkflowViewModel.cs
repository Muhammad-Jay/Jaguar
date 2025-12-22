using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Core.Models;
using Jaguar.Core.Services;
using Jaguar.Desktop.Services.AppState;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.ViewModels
{
    public partial class WorkflowViewModel : ViewModelBase
    {
        
        [ObservableProperty] private Orchestrator? _workFlowOrchestrator;
        [ObservableProperty] private AppStateService? _appState;
        [ObservableProperty] private OrchestratorAnalysis? _analysis;
        [ObservableProperty] private bool _isOverlayVisible;

        [RelayCommand] 
        public void ToggleOverlay()
        {
            IsOverlayVisible = !IsOverlayVisible;
        }
        
        // public async Task ShowDialogAsync()
        // {
        //     var dialog = new SettingsWindow();
        //     // 'this' is the parent window. 
        //     // ShowDialog makes it modal (locks the parent).
        //     await dialog.ShowDialog(this); 
        // }
        
        public WorkflowViewModel()
        {
            if (Program.AppHost != null)
            {
                // AppState = Program.AppHost.Services.GetRequiredService<AppStateService>();
                WorkFlowOrchestrator = Program.AppHost.Services.GetRequiredService<Orchestrator>();
            }
        }
        
        // [RelayCommand]
        // public async Task RunTestCommand()
        // {
        //     Console.WriteLine("Running Test Command...");
        //     string testPrompt = "Design a small console app that logs Zorin OS system temperatures.";
        //     
        //     Analysis = await WorkFlowOrchestrator.InitializeProjectAsync(testPrompt);
        // }
    }
}