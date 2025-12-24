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
        [ObservableProperty] private string _layoutPath =
            "M20 0.5H190.879C197.186 0.500154 203.025 3.82824 206.239 9.25488C209.634 14.9855 215.8 18.4999 222.46 18.5H685.314C691.366 18.5 696.807 14.8085 699.043 9.18457C701.127 3.94159 706.199 0.500136 711.841 0.5H927C937.77 0.500013 946.5 9.23046 946.5 20V686C946.5 696.77 937.77 705.5 927 705.5H20C9.23045 705.5 0.5 696.77 0.5 686V502.177C0.5 497.185 3.05324 492.54 7.26758 489.865C11.7711 487.007 14.5 482.043 14.5 476.709V224.646C14.5 219.293 12.4065 214.153 8.66699 210.323L6.04883 207.642C2.49167 203.999 0.5 199.109 0.5 194.018V20C0.500003 9.23045 9.23045 0.5 20 0.5Z";

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