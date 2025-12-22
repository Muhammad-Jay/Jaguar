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
            if (Program.AppHost != null)
            {
                AppState = Program.AppHost.Services.GetRequiredService<AppStateService>();
            }
        }
    }
}