using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Desktop.Services.AppState;

namespace Jaguar.Desktop.ViewModels;

public partial class ProjectDashboardViewModel: ViewModelBase
{
    private readonly IServiceProvider _serviceProvider;
    [ObservableProperty] private AppStateService _appState;
    
    public ProjectDashboardViewModel(IServiceProvider serviceProvider, AppStateService appStateService)
    {
        _serviceProvider = serviceProvider;
        AppState = appStateService;
        
        Console.WriteLine("--> Project Dashboard loaded.");
    }
    
    [RelayCommand]
    public void ToggleDialog() => AppState.IsCreateProjectDialogOpen = !AppState.IsCreateProjectDialogOpen;
}