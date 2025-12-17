using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Jaguar.Desktop.Models;
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