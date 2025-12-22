using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Jaguar.Desktop.ViewModels.MenuItemViewModel;

namespace Jaguar.Desktop.CustomViews.MenuItemView;

public partial class SettingsView : UserControl
{
    public SettingsView()
    {
        InitializeComponent();
        DataContext = new SettingsViewModel();
    }
}