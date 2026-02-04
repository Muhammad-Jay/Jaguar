using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Jaguar.Desktop.ViewModels;


namespace Jaguar.Desktop.Views;

public partial class ProjectsView : UserControl
{
    private ProjectsViewModel? ViewModel => DataContext as ProjectsViewModel;
    public ProjectsView()
    {
        InitializeComponent();
    }

    private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (e.ClickCount == 2 && ViewModel is not null)
        {
            
        }
    }
}