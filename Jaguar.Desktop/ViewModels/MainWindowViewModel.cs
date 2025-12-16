using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;

namespace Jaguar.Desktop.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ViewModelBase _content;
        
        public MainWindowViewModel()
        {
            Content = new WorkflowViewModel();
        }
    }
}