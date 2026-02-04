using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Services.AppState;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.ViewModels;

public partial class SplashScreenViewModel: ViewModelBase
{
    private readonly IServiceProvider _serviceProvider;
    [ObservableProperty] private AppStateService _appState;
    
    public SplashScreenViewModel(IServiceProvider serviceProvider, AppStateService appStateService)
    {
        Console.WriteLine("--> Attempting to load splash screen...");
        _serviceProvider = serviceProvider;
        AppState = appStateService;
        
        Console.WriteLine("--> Splash screen loaded.");
    }

    public async Task Load()
    {
        if (AppState == null) return;

        Console.WriteLine("--> Loading data...");
        
        AppState.LoadAllProjects();
        
        await Task.Delay(4000);
        
        AppState.SetView(AppScreen.Projects);
    }
}