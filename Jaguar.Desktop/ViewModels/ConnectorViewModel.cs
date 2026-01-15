using CommunityToolkit.Mvvm.ComponentModel;
using Jaguar.Desktop.Models;

namespace  Jaguar.Desktop.ViewModels;

public sealed partial class ConnectorViewModel : ObservableObject
{
    public PortDirection Direction { get; }
    
    [ObservableProperty]
    private bool _isConnected;
    public AnchorViewModel Anchor { get; }

    public ConnectorViewModel(PortDirection direction)
    {
        Direction = direction;
        Anchor = new AnchorViewModel(direction);
    }
}