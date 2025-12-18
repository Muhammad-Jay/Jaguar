using CommunityToolkit.Mvvm.ComponentModel;
using Jaguar.Core.Services;

namespace Jaguar.Desktop.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty] private ViewModelBase _content;
        
        public MainWindowViewModel(Orchestrator orchestrator)
        {
            Content = new WorkflowViewModel();
        }
    }
}