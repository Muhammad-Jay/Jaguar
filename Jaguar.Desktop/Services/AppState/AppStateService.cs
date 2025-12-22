using CommunityToolkit.Mvvm.ComponentModel;
using Jaguar.Desktop.Abstractions;
using Jaguar.Desktop.Models.Ui;
using Jaguar.Desktop.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.Services.AppState
{
    public partial class AppStateService: ObservableObject, IAppStateService
    {
        [ObservableProperty] private object? _currentView;
        [ObservableProperty] private PanelRequest? _activePanel;
        [ObservableProperty] private bool _isPanelOpen;

        public AppStateService()
        {
            if (Program.AppHost != null)
            {
                CurrentView = Program.AppHost.Services.GetRequiredService<WorkflowViewModel>();
                ActivePanel = new PanelRequest { ViewModel = CurrentView, Position = Position.Left};
                IsPanelOpen = false;
            }
        }
        
        
        public void RequestPanel(object vm, Position pos, double? size = 350)
        {
            if (ActivePanel?.ViewModel.GetType() == vm.GetType())
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
    }
}