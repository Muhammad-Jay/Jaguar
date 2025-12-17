using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.ViewModels.Menus;

namespace Jaguar.Desktop.CustomViews.ManuBars;

public partial class BottomMenuBarView : UserControl
{
    public BottomMenuBarView()
    {
        InitializeComponent();
        
        DataContext = new BottomBarMenuViewModel();
    }
}