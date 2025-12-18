using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Core.Abstractions;
using Jaguar.Core.Services;
using Jaguar.Desktop.Models;
using Jaguar.LLM.Services;

namespace Jaguar.Desktop.ViewModels.Menus
{
    public partial class  LeftBarMenuViewModel: ViewModelBase
    {
        public ObservableCollection<MenuItems> MenuItems { get; }

        public LeftBarMenuViewModel()
        {
            MenuItems = new ObservableCollection<MenuItems>
            {
                new MenuItems("A"), // Explorer
                new MenuItems("B"), // Agents
                new MenuItems("C️"), // Workflows
                new MenuItems("D"), // Knowledge
                new MenuItems("E")  // Settings
            };
        }
    }
}