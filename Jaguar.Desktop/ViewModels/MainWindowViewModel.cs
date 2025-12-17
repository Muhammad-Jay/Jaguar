using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Desktop.Models;

namespace Jaguar.Desktop.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty] private ViewModelBase _content;
        [ObservableProperty] private string _isDialogOpen = "Left";

        public ObservableCollection<string> MenuItems {get; set;}
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
            MenuItems = new ObservableCollection<string>()
            {
                "t",
                "y"
            };
            Console.WriteLine(MenuItems.Count);
        }
    }
}