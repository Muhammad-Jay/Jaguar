using System;
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
        private readonly IServiceProvider _serviceProvider;
        [ObservableProperty] private AppStateService? _appState;
        public ObservableCollection<MenuItems> MenuItems {get;}

        public RightBarMenuViewModel(AppStateService appState, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            AppState = appState;
            Console.WriteLine($"Menu Init: AppState is {(appState != null ? "Active" : "Null")}");
            MenuItems = new ObservableCollection<MenuItems>()
            {
                new MenuItems(" ",  MaterialIconKind.Home, serviceProvider.GetRequiredService<AgentTemplatesViewModel>(), Position.Right), // Explorer
                new MenuItems(" ",  MaterialIconKind.Settings, serviceProvider.GetRequiredService<SettingsViewModel>(), Position.Right), // Agents
                // new MenuItems("C️", "Workflows", "Right"), // Workflows
                // new MenuItems("D", "Knowledge", "Right"), // Knowledge
            };
        }
        
        [RelayCommand]
        public void TogglePanel () =>  AppState.IsRightPanelOpen = !AppState.IsRightPanelOpen;
        
        [RelayCommand]
        public void OnSelectedMenuChange(MenuItems? item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (AppState != null && Program.AppHost != null)
            {
               
                AppState.CurrentView = item.ViewModel;
                AppState.RequestPanel(item.ViewModel, item.Position);
            }
        }
    }
}