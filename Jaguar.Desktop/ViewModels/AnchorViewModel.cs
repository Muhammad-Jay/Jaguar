using System;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Jaguar.Desktop.ViewModels;
public partial class AnchorViewModel : ObservableObject
{
    [ObservableProperty] private Point _position;
    private readonly PortDirection _direction;

    public AnchorViewModel(PortDirection direction)
    {
        _direction = direction;
    }

    public void Update(Point nodeLocation, Size nodeSize)
    {
        Position = _direction == PortDirection.Input
            ? new Point(nodeLocation.X, nodeLocation.Y + nodeSize.Height / 2)
            : new Point(nodeLocation.X + nodeSize.Width, nodeLocation.Y + nodeSize.Height / 2);
    }
}
