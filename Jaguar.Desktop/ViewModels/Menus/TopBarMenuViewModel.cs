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
                new MenuItems("File"),
                new MenuItems("Edit"),
                new MenuItems("Build"),
                new MenuItems("Run"),
                new MenuItems("Tools"),
                new MenuItems("Git"),
                new MenuItems("Window"),
                new MenuItems("Help")
            };
        }
    }
}

