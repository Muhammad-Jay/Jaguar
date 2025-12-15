using ReactiveUI;

namespace Jaguar.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _content;
        
        // This public property is bound to the ContentControl in MainWindow.axaml
        public ViewModelBase Content 
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public MainWindowViewModel()
        {
            // Set the starting screen when the app opens
            Content = new WorkflowViewModel();
        }
    }
}