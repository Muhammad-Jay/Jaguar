using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Services.AppState;
using Jaguar.Desktop.ViewModels.Menus;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.CustomViews.ManuBars;

public partial class LeftMenuBarView : UserControl
{
    public object? AppState;
    public LeftMenuBarView()
    {
        InitializeComponent();
        AppState = Program.AppHost?.Services.GetRequiredService<AppStateService>();
        DataContext = new LeftBarMenuViewModel(AppState);
    }
}