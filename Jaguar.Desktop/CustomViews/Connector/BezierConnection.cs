using System;
using Avalonia;
using Avalonia.Media;
using GenerativeAI.Types;
using Nodify.Avalonia.Connections;

namespace Jaguar.Desktop.CustomViews.Connector;

public class BezierConnection : Connection
{
    
    protected Geometry CreateGeometry()
    {
        // Use the base class Source and Target points
        Point start = Source;
        Point end = Target;

        var dx = Math.Abs(end.X - start.X);
        var controlOffset = Math.Max(60, dx * 0.5);

        // Adjust control points based on flow direction
        // If start is to the right of end, we might need to flip offsets
        var c1 = new Point(start.X + controlOffset, start.Y);
        var c2 = new Point(end.X - controlOffset, end.Y);

        return new PathGeometry
        {
            Figures =
            {
                new PathFigure
                {
                    StartPoint = start,
                    IsClosed = false,
                    Segments =
                    {
                        new BezierSegment
                        {
                            Point1 = c1,
                            Point2 = c2,
                            Point3 = end
                        }
                    }
                }
            }
        };
    }
}