using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Jaguar.Desktop.ViewModels;

public sealed partial class NodeOverlayViewModel: ObservableObject
{
    public FlowNodeViewModel Node { get; }

    [ObservableProperty] private Point _screenPosition;

    public NodeOverlayViewModel(FlowNodeViewModel node)
    {
        this.Node = node;
    }
}