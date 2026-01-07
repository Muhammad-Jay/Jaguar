using System;
using Avalonia;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using Jaguar.Desktop.ViewModels;

namespace Jaguar.Desktop.Models;

public class ConnectionViewModel : ViewModelBase
{
    public Anchor Source { get; }
    public Anchor Target { get; }

    public ConnectionViewModel(Anchor source, Anchor target)
    {
        Source = source;
        Target = target;
    }
}


public partial class Anchor : ViewModelBase
{
    public string NodeId { get; }
    public PortDirection Direction { get; }

    [ObservableProperty]
    private Point _position;

    public Anchor(string nodeId, PortDirection direction)
    {
        NodeId = nodeId;
        Direction = direction;
    }
}
public partial class ConnectorViewModel : ViewModelBase
{
    public string NodeId { get; }
    public string Name { get; }
    public PortDirection Direction { get; }

    [ObservableProperty]
    private bool _isConnected;

    public Anchor Anchor { get; }

    public ConnectorViewModel(string nodeId, string name, PortDirection direction)
    {
        NodeId = nodeId;
        Name = name;
        Direction = direction;

        Anchor = new Anchor(nodeId, direction);
    }
}

public enum PortDirection
{
    Input,
    Output
}

