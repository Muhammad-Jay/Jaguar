using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Core.Models;
using Jaguar.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.ViewModels
{
    public partial class WorkflowViewModel : ViewModelBase
    {
        private readonly Orchestrator _orchestrator;
        [ObservableProperty] private OrchestratorAnalysis _analysis;
        [ObservableProperty] private string _isDialogOpen = "Run Command";
        [ObservableProperty] private string _agentSelectionStatus = "Select PM Agent";
        [ObservableProperty] private bool _isOverlayVisible;

        [RelayCommand] 
        public void ToggleOverlay()
        {
            IsOverlayVisible = !IsOverlayVisible;
        }
        
        [RelayCommand]
        public void SetAgentStatus()
        {
            Console.WriteLine(AgentSelectionStatus);
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
                _orchestrator = Program.AppHost.Services.GetRequiredService<Orchestrator>();
            }
        }
        
        [RelayCommand]
        public async Task RunTestCommand()
        {
            IsDialogOpen = "Running Test Command...";
            Console.WriteLine("Running Test Command...");
            string testPrompt = "Design a small console app that logs Zorin OS system temperatures.";
            
            Analysis = await _orchestrator.InitializeProjectAsync(testPrompt);
            IsDialogOpen = Analysis.Goal;
        }
    }
}