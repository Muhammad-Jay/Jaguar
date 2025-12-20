using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Jaguar.Desktop.ViewModels.Panel;

namespace Jaguar.Desktop.CustomViews.Panels;

public partial class PanelWrapper : UserControl
{
    public PanelWrapper()
    {
        InitializeComponent();
        DataContext = new PanelWrapperViewModel();
    }
}