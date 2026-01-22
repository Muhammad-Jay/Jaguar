using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Jaguar.Desktop.ViewModels;

namespace Jaguar.Desktop.Views;

public partial class SplashScreenView : UserControl
{
    private SplashScreenViewModel? ViewModel => DataContext as SplashScreenViewModel;
    public SplashScreenView()
    {
        InitializeComponent();
    }

    protected override async void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        if (ViewModel != null)
        {
            await ViewModel.Load();
        }
    }
}