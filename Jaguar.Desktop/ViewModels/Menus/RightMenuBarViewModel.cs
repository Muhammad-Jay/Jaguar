using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Services.AppState;
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
                // new MenuItems("A", "Explorer", "Right"), // Explorer
                // new MenuItems("B", "Explorer", "Right"), // Agents
                // new MenuItems("C️", "Workflows", "Right"), // Workflows
                // new MenuItems("D", "Knowledge", "Right"), // Knowledge
            };
        }
    }
}