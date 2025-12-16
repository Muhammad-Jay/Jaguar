using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Jaguar.Desktop.ViewModels
{
    public partial class WorkflowViewModel : ViewModelBase
    {
        public string ViewHeader => "AI Workflow Canvas - Project: Jaguar";
        
        [ObservableProperty]
        private string _agentSelectionStatus = "Select PM Agent";

        [RelayCommand]
        public void SetAgentStatus()
        {
            Console.WriteLine(AgentSelectionStatus);
        }
        
        public WorkflowViewModel()
        {
            // Here is where you would initialize the list of agents
            // and load the current project files from Jaguar.Core
        }
    }
}