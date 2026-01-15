using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.PanAndZoom;
using Avalonia.Media;

namespace Jaguar.Desktop.CustomViews.Controls;
public class GridOverlay : Control
{
    public static readonly StyledProperty<ZoomBorder?> ZoomBorderProperty =
        AvaloniaProperty.Register<GridOverlay, ZoomBorder?>(nameof(ZoomBorder));

    public ZoomBorder? ZoomBorder
    {
        get => GetValue(ZoomBorderProperty);
        set => SetValue(ZoomBorderProperty, value);
    }

    protected void OnRender(DrawingContext context)
    {
        if (ZoomBorder is null || !ZoomBorder.ShowGrid)
            return;

        var gridSize = ZoomBorder.GridSize;
        if (gridSize <= 0)
            return;

        var bounds = Bounds;

        // Convert view bounds → content space
        var topLeft = ZoomBorder.ViewportToContent(new Point(0, 0));
        var bottomRight = ZoomBorder.ViewportToContent(new Point(bounds.Width, bounds.Height));

        double startX = Math.Floor(topLeft.X / gridSize) * gridSize;
        double startY = Math.Floor(topLeft.Y / gridSize) * gridSize;

        double scale = 1.0;

        if (ZoomBorder.RenderTransform is MatrixTransform mt)
        {
            scale = mt.Matrix.M11;
        }

        var minorPen = new Pen(
            ZoomBorder.GridBrush,
            ZoomBorder.GridThickness / scale
        );

        var majorPen = new Pen(
            ZoomBorder.MajorGridBrush,
            ZoomBorder.MajorGridThickness / scale
        );

        for (double x = startX; x < bottomRight.X; x += gridSize)
        {
            var pen = IsMajorLine(x, gridSize, ZoomBorder.MajorGridInterval)
                ? majorPen
                : minorPen;

            var p1 = ZoomBorder.ContentToViewport(new Point(x, topLeft.Y));
            var p2 = ZoomBorder.ContentToViewport(new Point(x, bottomRight.Y));
            context.DrawLine(pen, p1, p2);
        }

        for (double y = startY; y < bottomRight.Y; y += gridSize)
        {
            var pen = IsMajorLine(y, gridSize, ZoomBorder.MajorGridInterval)
                ? majorPen
                : minorPen;

            var p1 = ZoomBorder.ContentToViewport(new Point(topLeft.X, y));
            var p2 = ZoomBorder.ContentToViewport(new Point(bottomRight.X, y));
            context.DrawLine(pen, p1, p2);
        }
    }

    private static bool IsMajorLine(double value, double gridSize, int interval)
    {
        if (interval <= 0)
            return false;

        var index = Math.Round(value / gridSize);
        return index % interval == 0;
    }
}
