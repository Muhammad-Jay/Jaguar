using System;
using Avalonia;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Services.AppState;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace Jaguar.Desktop.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly IServiceProvider _serviceProvider;
       
        [ObservableProperty] private AppStateService _appState;
        [ObservableProperty] private bool _isRightPanelOpen = true;

        [ObservableProperty] private bool _isSplashScreen;
        [ObservableProperty] private Size _size;
        [ObservableProperty] private Color? _color;
        
        public MainWindowViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            AppState = _serviceProvider.GetRequiredService<AppStateService>();
            Size = new Size(600, 500);
            AppState.SetView(AppScreen.SplashScreen);
            IsSplashScreen = true;
            Console.WriteLine("--> Main window view model loaded.");
        }

        [RelayCommand]
        public void SetHomeView()
        {
            if (AppState.CurrentScreenType == AppScreen.Projects)
                return;
            
            AppState.SetView(AppScreen.Projects);
        }
    }
}