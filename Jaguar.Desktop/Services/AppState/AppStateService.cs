using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Desktop.Abstractions;
using Jaguar.Desktop.CustomViews.Templates;
using Jaguar.Desktop.Models.Ui;

namespace Jaguar.Desktop.Services.AppState
{
    public partial class AppStateService: ObservableObject, IAppStateService
    {
        [ObservableProperty] private object? _currentView;
        [ObservableProperty] private PanelRequest? _activePanel;
        [ObservableProperty] private bool _isPanelOpen = true;

        // Workflow Dialogs States
        [ObservableProperty] private bool _isAgentDialogOpen;
        
        public AppStateService()
        {
            if (Program.AppHost != null)
            {
                CurrentView = new AgentTemplatesView();
                ActivePanel = new PanelRequest { ViewModel = CurrentView, Position = Position.Left};
                IsPanelOpen = false;
                IsAgentDialogOpen = false;
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