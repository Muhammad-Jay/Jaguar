using System;
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
    [ObservableProperty] private object? _content;
    [ObservableProperty] private AppStateService? _appState;

    [ObservableProperty] private string _panelPath =
            "M0 20C0 8.95428 8.95431 0 20 0H284C295.046 0 304 8.95431 304 20V311.016C304 316.895 306.587 322.477 311.074 326.278L324.926 338.009C329.413 341.809 332 347.391 332 353.271V656C332 667.046 323.046 676 312 676H20C8.95431 676 0 667.046 0 656V329.246V218.849V20Z"; 
    
    public ObservableCollection<MenuItems>? ItemList { get; } 
    
    public WorkflowSidebarPanelViewModel(IServiceProvider serviceProvider)
    {
        AppState = serviceProvider.GetRequiredService<AppStateService>();

        // Initialize UI data
        Content = serviceProvider.GetRequiredService<AgentTemplatesViewModel>();
        
        ItemList = new ObservableCollection<MenuItems>()
        {
            new MenuItems("Properties", MaterialIconKind.Settings, serviceProvider.GetRequiredService<AgentTemplatesViewModel>(), Position.Right),
            new MenuItems("Inspector", MaterialIconKind.Eye, serviceProvider.GetRequiredService<SettingsViewModel>(), Position.Right),
            new MenuItems("Agents", MaterialIconKind.CardSearch, serviceProvider.GetRequiredService<AgentTemplatesViewModel>(), Position.Right),
            new MenuItems("History", MaterialIconKind.History, serviceProvider.GetRequiredService<AgentTemplatesViewModel>(), Position.Right)
        };
    }

    
    [RelayCommand]
    public void OnSelectedMenuChange(MenuItems? item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        if (AppState != null)
        {
            AppState.CurrentView = item.ViewModel;
        }
    }
}