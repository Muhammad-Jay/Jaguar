using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Desktop.Models;

namespace Jaguar.Desktop.ViewModels.Menus
{
    public partial class  LeftBarMenuViewModel: ViewModelBase
    {
        public ObservableCollection<MenuItems> MenuItems { get; }

        public LeftBarMenuViewModel()
        {
            MenuItems = new ObservableCollection<MenuItems>
            {
                new MenuItems("📁"), // Explorer
                new MenuItems("🤖"), // Agents
                new MenuItems("🕸️"), // Workflows
                new MenuItems("📚"), // Knowledge
                new MenuItems("⚙️")  // Settings
            };
        }
    }
}