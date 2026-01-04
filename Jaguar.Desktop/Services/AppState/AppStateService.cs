using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Desktop.Abstractions;
using Jaguar.Desktop.CustomViews.Templates;
using Jaguar.Desktop.Models.Ui;
using Jaguar.Desktop.ViewModels.Dialog.Contents;
using Jaguar.Desktop.ViewModels.Templates;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.Services.AppState
{
    public partial class AppStateService: ObservableObject, IAppStateService
    {
        private readonly IServiceProvider _serviceProvider;
        [ObservableProperty] private object? _currentView;
        [ObservableProperty] private object? _currentDialogView;
        [ObservableProperty] private PanelRequest? _activePanel;
        [ObservableProperty] private bool _isPanelOpen = true;

        // Workflow Dialogs States
        [ObservableProperty] private bool _isAgentDialogOpen;
        
        public AppStateService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeServices();
        }
        
        private void InitializeServices()
        {
            try
            {
                if (Program.AppHost != null)
                {
                    CurrentView = _serviceProvider.GetRequiredService<AgentTemplatesViewModel>();
                    CurrentDialogView = new OrchestratorDialogPromptViewModel();
                    ActivePanel = new PanelRequest { ViewModel = CurrentView, Position = Position.Left};
                    IsPanelOpen = false;
                    IsAgentDialogOpen = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Service Init Error: {ex.Message}");
            }
        }
        
        
        public void RequestPanel(object vm, Position pos, double? size = 350)
        {
            if (ActivePanel?.ViewModel == vm)
            {
                IsPanelOpen = false;
                ActivePanel = null;
            }
            else
            {
                ActivePanel = new PanelRequest { ViewModel = vm, Position = pos, Size = size };
                IsPanelOpen = true;
            }
        }
   
        public void ClosePanel () =>  IsPanelOpen = false;
        
        [RelayCommand]
        public void TogglePanel () =>  IsPanelOpen = !IsPanelOpen;
        
    }
}