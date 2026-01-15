using System;
using Avalonia;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Jaguar.Desktop.ViewModels;

public partial class ConnectionViewModel : ViewModelBase
{
    public AnchorViewModel Source { get; }
    public AnchorViewModel Target { get; }

    [ObservableProperty] private Geometry? _geometry = new PathGeometry();
    public ConnectionViewModel(AnchorViewModel source, AnchorViewModel target)
    {
        Source = source;
        Target = target;
        
        Source.PropertyChanged += (_, e) =>
        {
            if (e.PropertyName == nameof(AnchorViewModel.Position))
                Update();
        };

        Target.PropertyChanged += (_, e) =>
        {
            if (e.PropertyName == nameof(AnchorViewModel.Position))
                Update();
        };

        Update();
    }
    
    private void Update()
    {
        var from = Source.Position;
        var to = Target.Position;

        var dx = Math.Abs(to.X - from.X);
        var offset = Math.Max(80, dx * 0.5);

        var c1 = new Point(from.X + offset, from.Y);
        var c2 = new Point(to.X - offset, to.Y);
        
        if (from == to)
        {
            Geometry = null;
            return;
        }

        Geometry = new PathGeometry
        {
            Figures =
            {
                new PathFigure
                {
                    StartPoint = from,
                    Segments =
                    {
                        new BezierSegment
                        {
                            Point1 = c1,
                            Point2 = c2,
                            Point3 = to
                        }
                    }
                }
            }
        };
    }
}

public enum PortDirection
{
    Input,
    Output
}
