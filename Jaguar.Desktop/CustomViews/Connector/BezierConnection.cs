using System;
using Avalonia;
using Avalonia.Media;
using Nodify;

namespace Jaguar.Desktop.CustomViews.Connector;

public class BezierConnection : Connection
{
    protected Geometry CreateGeometry(Point from, Point to)
    {
        var dx = Math.Abs(to.X - from.X);

        var controlOffset = Math.Max(60, dx * 0.5);

        var c1 = new Point(from.X + controlOffset, from.Y);
        var c2 = new Point(to.X - controlOffset, to.Y);

        return new PathGeometry
        {
            Figures =
            {
                new PathFigure
                {
                    StartPoint = from,
                    IsClosed = false,
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