using CommunityToolkit.Mvvm.ComponentModel;
using Jaguar.Core.Services;

namespace Jaguar.Desktop.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty] private ViewModelBase _content;
        [ObservableProperty] private bool _isRightPanelOpen = true;
        
        public MainWindowViewModel()
        {
            Content = new WorkflowViewModel();
        }
    }
}