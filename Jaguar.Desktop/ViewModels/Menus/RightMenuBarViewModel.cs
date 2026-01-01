using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Desktop.CustomViews.Templates;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Models.Ui;
using Jaguar.Desktop.Services.AppState;
using Jaguar.Desktop.ViewModels.MenuItemViewModel;
using Jaguar.Desktop.ViewModels.Templates;
using Material.Icons;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.ViewModels.Menus
{
    public partial class  RightBarMenuViewModel: ViewModelBase
    {
        [ObservableProperty] private AppStateService? _appState;
        public ObservableCollection<MenuItems> MenuItems {get; set;}

        public RightBarMenuViewModel()
        {
            if (Program.AppHost != null)
            {
                AppState = Program.AppHost.Services.GetRequiredService<AppStateService>();
            }
            MenuItems = new ObservableCollection<MenuItems>()
            {
                new MenuItems(" ",  MaterialIconKind.Settings, new AgentTemplatesView(), Position.Right), // Explorer
                // new MenuItems("B", "Explorer", "Right"), // Agents
                // new MenuItems("C️", "Workflows", "Right"), // Workflows
                // new MenuItems("D", "Knowledge", "Right"), // Knowledge
            };
        }
        
        [RelayCommand]
        public void TogglePanel () =>  AppState.IsPanelOpen = !AppState.IsPanelOpen;
    }
}