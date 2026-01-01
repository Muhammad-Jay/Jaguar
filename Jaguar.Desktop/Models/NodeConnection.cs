using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using Jaguar.Desktop.ViewModels;

namespace Jaguar.Desktop.Models;

public partial class ConnectionViewModel : ViewModelBase
{
    [ObservableProperty]
    private Anchor _sourceAnchor;
       
    [ObservableProperty]
    private Anchor _targetAnchor;
    
    public ConnectionViewModel(Anchor source, Anchor target)
    {
        SourceAnchor = source;
        TargetAnchor = target;
    }
}

public partial class Anchor: ViewModelBase
{
    [ObservableProperty]
        private Point _position;
}

public partial class ConnectorViewModel : ViewModelBase
{
    public string Name {get; set;}
    public FlowNode ParentNode { get; }
    
    public Anchor Anchor { get; } = new();

    public ConnectorViewModel(FlowNode parent, string name)
    {
        ParentNode = parent;
        Name = name;
    }
}