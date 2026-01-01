using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Desktop.CustomViews.MenuItemView;
using Jaguar.Desktop.CustomViews.Templates;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Models.Ui;
using Jaguar.Desktop.Services.AppState;
using Jaguar.Desktop.ViewModels.MenuItemViewModel;
using Jaguar.Desktop.ViewModels.Templates;
using Material.Icons;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.ViewModels.Panel;

public partial class  WorkflowSidebarPanelViewModel: ViewModelBase
{
    [ObservableProperty] private object _content;
    [ObservableProperty] private AppStateService? _appState;

    [ObservableProperty] private string _panelPath =
            "M0 20C0 8.95428 8.95431 0 20 0H284C295.046 0 304 8.95431 304 20V311.016C304 316.895 306.587 322.477 311.074 326.278L324.926 338.009C329.413 341.809 332 347.391 332 353.271V656C332 667.046 323.046 676 312 676H20C8.95431 676 0 667.046 0 656V329.246V218.849V20Z"; 
    
    public ObservableCollection<MenuItems> ItemList { get; set; } 
    
    public WorkflowSidebarPanelViewModel()
    {
        Content = new AgentTemplatesView();
        
        if (Program.AppHost != null)
        {
            AppState = Program.AppHost.Services.GetRequiredService<AppStateService>();
        }
        
        ItemList = new ObservableCollection<MenuItems>()
        {
            new MenuItems("Properties", MaterialIconKind.Settings, typeof(AgentTemplatesViewModel), Position.Right),
            new MenuItems("Inspector", MaterialIconKind.Eye, typeof(SettingsViewModel), Position.Right),
            new MenuItems("Agents", MaterialIconKind.CardSearch, typeof(AgentTemplatesViewModel), Position.Right),
            new MenuItems("History", MaterialIconKind.History, typeof(AgentTemplatesViewModel), Position.Right)
        };
    }
    
    [RelayCommand]
    private void SelectMenuItem(MenuItems selectedItem)
    {
        if (Program.AppHost != null)
        {
            WorkflowSidebarPanelViewModel currentVm = Program.AppHost.Services.GetRequiredService<WorkflowSidebarPanelViewModel>();
            
                currentVm.SetContent(selectedItem.ViewModel);
        }
    }

    public void SetContent(object content)
    {
        Content = content;
    }
}