using Avalonia.Controls;
using Jaguar.Desktop.ViewModels.Menus;

namespace Jaguar.Desktop.CustomViews.ManuBars;

public partial class LeftMenuBarView : UserControl
{
    public LeftMenuBarView()
    {
        InitializeComponent();
        DataContext = new LeftBarMenuViewModel();
    }
}