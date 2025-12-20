using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Core.Abstractions;
using Jaguar.Core.Services;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Services.AppState;
using Jaguar.LLM.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.ViewModels.Menus
{
    public partial class  LeftBarMenuViewModel: ViewModelBase
    {
        public ObservableCollection<MenuItems> MenuItems { get; }

        public LeftBarMenuViewModel(object? appState)
        {
            MenuItems = new ObservableCollection<MenuItems>
            {
                new MenuItems("A", "Status", "Left"), // Explorer
                new MenuItems("B", "Agents", "Left"), // Agents
                new MenuItems("C️", "Workflows", "Left"), // Workflows
                new MenuItems("D", "Knowledge", "Left"), // Knowledge
                new MenuItems("E", "Settings", "Left")  // Settings
            };
        }
    }
}