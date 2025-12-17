using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Desktop.Models;

namespace Jaguar.Desktop.ViewModels.Menus
{
    public partial class  TopBarMenuViewModel: ViewModelBase
    {
        [ObservableProperty]
        private ObservableCollection<MenuItems> _menuItems = new ObservableCollection<MenuItems>()
        {
            new MenuItems("i"),
            new MenuItems("2"),
            new MenuItems("i"),
            new MenuItems("2"),
            new MenuItems("i"),
            new MenuItems("2"),
            new MenuItems("i"),
            new MenuItems("2"),
            new MenuItems("i"),
            new MenuItems("2"),
        };
    }
}

