using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Jaguar.Desktop.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty] private ViewModelBase _content;
        [ObservableProperty] private string _isDialogOpen = "Left";

        [RelayCommand]
        private void OpenDialog()
        {
            if (IsDialogOpen == "Left")
            {
                IsDialogOpen = "Right";
            }
            else
            {
                IsDialogOpen = "Left";
            }
        }
        
        [RelayCommand]
        private void SetContent()
        {
            Content = new WorkflowViewModel();
        }
        public MainWindowViewModel()
        {
            Content = new WorkflowViewModel();
        }
    }
}