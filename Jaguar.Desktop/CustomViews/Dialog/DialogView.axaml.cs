using Avalonia.Controls;
using Jaguar.Desktop.ViewModels;
using Jaguar.Desktop.ViewModels.Dialog;

namespace Jaguar.Desktop.CustomViews.Dialog;

public partial class DialogView : UserControl
{
    public DialogView()
    {
        InitializeComponent();
        DataContext = new DialogViewModel();
    }
}