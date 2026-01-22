using System.Windows.Input;
using Avalonia;
using Material.Icons;

namespace Jaguar.Desktop.Models;

public class ToolMenuItem
{
    public string Text { get; init; } = string.Empty;
    public ICommand? Command { get; init; }
    public Size? Size { get; init; } = new Size(25, 25);

    public bool IsVertical { get; init; } = false; 
    public MaterialIconKind IconKind { get; init; }
}