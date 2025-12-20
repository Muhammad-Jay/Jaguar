using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Desktop.Models;

namespace Jaguar.Desktop.ViewModels.Menus
{
    public partial class  TopBarMenuViewModel: ViewModelBase
    {
        public ObservableCollection<MenuItems> MenuItems {get; set;}

        public TopBarMenuViewModel()
        {
            MenuItems = new ObservableCollection<MenuItems>()
            {
                new MenuItems("File", "File", "Top"),
                new MenuItems("Edit", "Edit", "Top"),
                new MenuItems("Build", "Build", "Top"),
                new MenuItems("Run", "Run", "Top"),
                new MenuItems("Tools", "Tools", "Top"),
                new MenuItems("Git", "Git", "Top"),
                new MenuItems("Window", "Window", "Top"),
                new MenuItems("Help", "Help", "Top")
            };
        }
    }
}

