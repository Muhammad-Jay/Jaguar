using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Services.AppState;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly IServiceProvider _serviceProvider;
       
        [ObservableProperty] private AppStateService _appState;
        [ObservableProperty] private bool _isRightPanelOpen = true;
        
        public MainWindowViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            AppState = _serviceProvider.GetRequiredService<AppStateService>();
            AppState.SetView(AppScreen.SplashScreen);
            Console.WriteLine("--> Main window view model loaded.");
        }
    }
}