using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Models.Ui;
using Jaguar.Desktop.Services.AppState;
using Jaguar.Desktop.ViewModels.MenuItemViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.ViewModels.Menus
{
    public partial class  LeftBarMenuViewModel: ViewModelBase
    {
        [ObservableProperty] private AppStateService? _appState;
        [ObservableProperty] private MenuItems? _selectedMenu;
        public ObservableCollection<MenuItems>? MenuItems { get; }

        public LeftBarMenuViewModel()
        {
            if (Program.AppHost != null)
            {
                AppState = Program.AppHost.Services.GetRequiredService<AppStateService>();
                
                MenuItems = new ObservableCollection<MenuItems>
                {
                    new MenuItems("S", typeof(SettingsViewModel), Position.Left), // Explorer
                    // new MenuItems("B", "Agents", "Left"), // Agents
                    // new MenuItems("C️", "Workflows", "Left"), // Workflows
                    // new MenuItems("D", "Knowledge", "Left"), // Knowledge
                    // new MenuItems("E", "Settings", "Left")  // Settings
                };
            }
        }

        [RelayCommand]
        public void OnSelectedMenuChange(MenuItems? item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (AppState != null && Program.AppHost != null)
            {
                var vm = Program.AppHost?.Services.GetRequiredService(item.viewModel);

                if (vm != null)
                {
                    AppState.CurrentView = vm;
                    AppState.RequestPanel(vm, item.Position);
                }
            }
        }
    }
}