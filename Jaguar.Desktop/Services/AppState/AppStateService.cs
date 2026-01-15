using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Core.Abstractions;
using Jaguar.Core.Models;
using Jaguar.Desktop.Abstractions;
using Jaguar.Desktop.CustomViews.Templates;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Models.Ui;
using Jaguar.Desktop.Services.Events.Ui;
using Jaguar.Desktop.ViewModels.Dialog.Contents;
using Jaguar.Desktop.ViewModels.Templates;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.Services.AppState
{
    public partial class AppStateService: ObservableObject, IAppStateService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IEventAggregator _events;

        [ObservableProperty] private Project? _currentProject;
        [ObservableProperty] private AppScreen _currentScreen;
        
        [ObservableProperty] private object? _currentView;
        [ObservableProperty] private object? _currentDialogView;
        [ObservableProperty] private PanelRequest? _activePanel;
        [ObservableProperty] private bool _isRightPanelOpen = true;
        [ObservableProperty] private bool _isLeftPanelOpen = false;
        [ObservableProperty] private bool _isTopPanelOpen = false;
        

        // Workflow Dialogs States
        private readonly double _defaultDialogWidth = 600;
        private readonly double _defaultDialogHeight = 500;
        
        [ObservableProperty] private bool _isAgentDialogOpen;
        [ObservableProperty] private double _dialogWidth;
        [ObservableProperty] private double _dialogHeight;
        
        public AppStateService(IServiceProvider serviceProvider, IEventAggregator eventAggregator)
        {
            _serviceProvider = serviceProvider;
            _events = eventAggregator;
            InitializeServices();
            SubscribeToEvents();
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
                    IsRightPanelOpen = false;
                    IsLeftPanelOpen = true;
                    IsTopPanelOpen = false;
                    IsAgentDialogOpen = false;
                    DialogWidth = _defaultDialogWidth;
                    DialogHeight = _defaultDialogHeight;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Service Init Error: {ex.Message}");
            }
        }
        
        private void SubscribeToEvents()
        {
            _events.Subscribe<OpenAgentTemplateDialogEvent>(_ => OpenOrchestratorDialog());

            _events.Subscribe<CloseDialogEvent>(_ =>
            {
                CurrentDialogView = null;
                IsAgentDialogOpen = false;
                DialogWidth = _defaultDialogWidth;
                DialogHeight = _defaultDialogHeight;
            });

            _events.Subscribe<OpenPanelEvent>(e =>
            {
                RequestPanel(e.ViewModel, e.Position, e.Size);
            });
        }
        
        
        public void RequestPanel(object vm, Position pos, double? size = 350)
        {
            if (ActivePanel?.ViewModel == vm)
            {
                switch (pos)
                {
                    case Position.Right:
                        IsRightPanelOpen = false;
                        ActivePanel = null;
                        break;
                    default:
                        return;
                        break;
                }
            }
            else
            {
                ActivePanel = new PanelRequest { ViewModel = vm, Position = pos, Size = size };
                IsRightPanelOpen = true;
            }
        }

        public void OpenOrchestratorDialog()
        {
            DialogWidth = 900;
            DialogHeight = 700;
            CurrentDialogView = _serviceProvider.GetRequiredService<OrchestratorDialogPromptViewModel>();
            IsAgentDialogOpen = true;
        }
   
        public void ClosePanel () =>  IsRightPanelOpen = false;
        
        [RelayCommand]
        public void TogglePanel () =>  IsRightPanelOpen = !IsRightPanelOpen;
        
    }
}