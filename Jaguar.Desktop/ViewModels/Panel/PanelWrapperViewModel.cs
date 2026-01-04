using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Jaguar.Desktop.Services.AppState;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.ViewModels.Panel
{
    public partial class PanelWrapperViewModel : ViewModelBase
    {
        [ObservableProperty] private ViewModelBase? _content;
        [ObservableProperty] private AppStateService? _appState;
        
        public PanelWrapperViewModel()
        {
            InitializeServices();
        }
        
        private void InitializeServices()
        {
            // try
            // {
            //     if (Program.AppHost != null)
            //     {
            //         AppState = Program.AppHost.Services.GetService<AppStateService>();
            //     }
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine($"Service Init Error: {ex.Message}");
            // }
        }
    }
}