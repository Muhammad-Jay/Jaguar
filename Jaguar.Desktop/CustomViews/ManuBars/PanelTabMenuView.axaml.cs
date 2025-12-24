using Avalonia.Controls;
using Jaguar.Desktop.ViewModels.Menus;

namespace Jaguar.Desktop.CustomViews.ManuBars;

public partial class PanelTabMenuView : UserControl
{
    public PanelTabMenuView()
    {
        InitializeComponent();

        DataContext = new PanelTabMenuViewModel();
    }
}