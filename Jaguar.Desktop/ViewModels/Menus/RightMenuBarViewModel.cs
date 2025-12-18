using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Desktop.Models;

namespace Jaguar.Desktop.ViewModels.Menus
{
    public partial class  RightBarMenuViewModel: ViewModelBase
    {
        public ObservableCollection<MenuItems> MenuItems {get; set;}

        public RightBarMenuViewModel()
        {
            MenuItems = new ObservableCollection<MenuItems>()
            {
                new MenuItems("A"), // Explorer
                new MenuItems("B"), // Agents
                new MenuItems("C️"), // Workflows
                new MenuItems("D"), // Knowledge
            };
        }
    }
}