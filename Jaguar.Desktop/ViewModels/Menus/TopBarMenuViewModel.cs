using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Services.AppState;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.ViewModels.Menus
{
    public partial class  TopBarMenuViewModel: ViewModelBase
    {
        [ObservableProperty] private AppStateService? _appState;
        public ObservableCollection<MenuItems> MenuItems {get; set;}

        public TopBarMenuViewModel()
        {
            if (Program.AppHost != null)
            {
                AppState = Program.AppHost.Services.GetRequiredService<AppStateService>();
            }
            MenuItems = new ObservableCollection<MenuItems>()
            {
                // new MenuItems("File", "File", "Top"),
                // new MenuItems("Edit", "Edit", "Top"),
                // new MenuItems("Build", "Build", "Top"),
                // new MenuItems("Run", "Run", "Top"),
                // new MenuItems("Tools", "Tools", "Top"),
                // new MenuItems("Git", "Git", "Top"),
                // new MenuItems("Window", "Window", "Top"),
                // new MenuItems("Help", "Help", "Top")
            };
        }
    }
}

