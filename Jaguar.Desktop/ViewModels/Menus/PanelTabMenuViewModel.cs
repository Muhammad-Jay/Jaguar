using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Desktop.Constants;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.ViewModels.Panel;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.ViewModels.Menus;

public partial class PanelTabMenuViewModel : ViewModelBase
{
    private ObservableCollection<MenuItems> ItemList { get; set; } 
    public PanelTabMenuViewModel()
    {
        ItemList = TabItemsList.ItemList;
    }

    [RelayCommand]
    private void SelectMenuItem(MenuItems selectedItem)
    {
        if (Program.AppHost != null)
        {
            WorkflowSidebarPanelViewModel currentVm = Program.AppHost.Services.GetRequiredService<WorkflowSidebarPanelViewModel>();
            var vm = Program.AppHost.Services.GetService(selectedItem.ViewModel);

            if (currentVm.Content != vm || vm != null)
            {
                currentVm.Content = (ViewModelBase)vm;
            }
        }
    }
}