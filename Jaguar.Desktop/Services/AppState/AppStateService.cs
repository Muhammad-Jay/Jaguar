using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Desktop.Abstractions;
using Jaguar.Desktop.CustomViews.Templates;
using Jaguar.Desktop.Models.Ui;
using Jaguar.Desktop.ViewModels;
using Jaguar.Desktop.ViewModels.Templates;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.Services.AppState
{
    public partial class AppStateService: ObservableObject, IAppStateService
    {
        [ObservableProperty] private object? _currentView;
        [ObservableProperty] private PanelRequest? _activePanel;
        [ObservableProperty] private bool _isPanelOpen = true;

        public AppStateService()
        {
            if (Program.AppHost != null)
            {
                CurrentView = Program.AppHost.Services.GetRequiredService<AgentTemplatesView>();
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
        
        [RelayCommand]
        public void ClosePanel () =>  IsPanelOpen = false;
        
        [RelayCommand]
        public void TogglePanel () =>  IsPanelOpen = !IsPanelOpen;
    }
}