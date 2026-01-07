using CommunityToolkit.Mvvm.ComponentModel;

namespace Jaguar.Desktop.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty] private ViewModelBase _content;
        [ObservableProperty] private bool _isRightPanelOpen = true;
        
        public MainWindowViewModel(WorkflowViewModel workflow)
        {
            Content = workflow;
        }
    }
}