using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Desktop.CustomViews.MenuItemView;
using Jaguar.Desktop.CustomViews.Templates;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Models.Ui;
using Jaguar.Desktop.ViewModels.Templates;
using Material.Icons;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.ViewModels.Panel;

public partial class  WorkflowSidebarPanelViewModel: ViewModelBase
{
    [ObservableProperty] private object _content;
    
    public ObservableCollection<MenuItems> ItemList { get; set; } 
    
    public WorkflowSidebarPanelViewModel()
    {
        Content = new AgentTemplatesView();
        
        ItemList = new ObservableCollection<MenuItems>()
        {
            new MenuItems("Properties", MaterialIconKind.Settings, typeof(AgentTemplatesView), Position.Right),
            new MenuItems("Inspector", MaterialIconKind.Eye, typeof(SettingsView), Position.Right),
            new MenuItems("Agents", MaterialIconKind.CardSearch, typeof(AgentTemplatesView), Position.Right),
            new MenuItems("History", MaterialIconKind.History, typeof(AgentTemplatesView), Position.Right)
        };
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
                currentVm.SetContent(vm);;
            }
        }
    }

    public void SetContent(object content)
    {
        Content = content;
    }
}