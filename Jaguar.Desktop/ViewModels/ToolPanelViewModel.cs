using System.Collections.ObjectModel;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Models.Ui;

namespace Jaguar.Desktop.ViewModels;

public partial class ToolPanelViewModel: ObservableObject
{
    [ObservableProperty] private string? _title;

    [ObservableProperty] private Orientation _orientation;

    public Size Size { get; init; }

    public string StackPanelOrientation => Orientation switch
    {
        Orientation.Vertical => "Vertical",
        _ => "Horizontal"
    };
    public ObservableCollection<ToolMenuItem> Items { get; init; } = new();
    
}

public enum Orientation
{
    Vertical,
    Horizontal
}