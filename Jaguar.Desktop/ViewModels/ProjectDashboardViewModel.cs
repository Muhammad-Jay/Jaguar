using System;
using CommunityToolkit.Mvvm.ComponentModel;
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
}