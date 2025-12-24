using Avalonia.Controls;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Jaguar.Desktop.Views
{
    public partial class CanvasView : UserControl
    {
        private bool _isDoubleTapPanMode = false;
        private Point _lastMousePosition;

        public CanvasView()
        {
            InitializeComponent();
        }

        // private void ZoomBorder_OnDoubleTapped(object? sender, TappedEventArgs e)
        // {
        //     if (ZoomBorder == null) return;
        //
        //     // Toggle pan mode on/off with double-click
        //     _isDoubleTapPanMode = !_isDoubleTapPanMode;
        //     
        //     if (_isDoubleTapPanMode)
        //     {
        //         // Enter pan mode
        //         _lastMousePosition = e.GetPosition(ZoomBorder);
        //         ZoomBorder.Cursor = new Cursor(StandardCursorType.Hand);
        //     }
        //     else
        //     {
        //         // Exit pan mode
        //         ZoomBorder.Cursor = Cursor.Default;
        //     }
        //     
        //     e.Handled = true;
        // }
        //
        // private void ZoomBorder_OnPointerMoved(object? sender, PointerEventArgs e)
        // {
        //     if (!_isDoubleTapPanMode || ZoomBorder == null) return;
        //
        //     var currentPosition = e.GetPosition(ZoomBorder);
        //     
        //     // Calculate delta from last position
        //     var deltaX = currentPosition.X - _lastMousePosition.X;
        //     var deltaY = currentPosition.Y - _lastMousePosition.Y;
        //     
        //     // Apply pan using matrix transformation
        //     var matrix = ZoomBorder.Matrix;
        //     matrix = MatrixHelper.TranslatePrepend(matrix, deltaX, deltaY);
        //     ZoomBorder.SetMatrix(matrix);
        //     
        //     // Update last position
        //     _lastMousePosition = currentPosition;
        //     
        //     e.Handled = true;
        // }
        //
        // private void ZoomBorder_OnPointerExited(object? sender, PointerEventArgs e)
        // {
        //     // Optional: Exit pan mode when pointer leaves the control
        //     // Uncomment if you want this behavior
        //     if (_isDoubleTapPanMode && ZoomBorder != null)
        //     {
        //         _isDoubleTapPanMode = false;
        //         ZoomBorder.Cursor = Cursor.Default;
        //     }
        // }
        //
        // private void CenterNodes()
        // {
        //     if (ZoomBorder == null || DataContext is not CanvasViewModel viewModel) return;
        //
        //     var nodes = viewModel.CurrentScope.Children;
        //     if (nodes == null || !nodes.Any()) return;
        //
        //     // Calculate bounding box of all nodes
        //     double minX = double.MaxValue;
        //     double minY = double.MaxValue;
        //     double maxX = double.MinValue;
        //     double maxY = double.MinValue;
        //
        //     foreach (var node in nodes)
        //     {
        //         minX = Math.Min(minX, node.X);
        //         minY = Math.Min(minY, node.Y);
        //         maxX = Math.Max(maxX, node.X + 200); // Assuming node width ~200
        //         maxY = Math.Max(maxY, node.Y + 100); // Assuming node height ~100
        //     }
        //
        //     // Calculate center of bounding box
        //     var centerX = (minX + maxX) / 2;
        //     var centerY = (minY + maxY) / 2;
        //
        //     // Calculate viewport center
        //     var viewportCenterX = ZoomBorder.Bounds.Width / 2;
        //     var viewportCenterY = ZoomBorder.Bounds.Height / 2;
        //
        //     // Get current zoom
        //     var zoom = ZoomBorder.ZoomX;
        //
        //     // Calculate offset to center the nodes
        //     var offsetX = viewportCenterX - (centerX * zoom);
        //     var offsetY = viewportCenterY - (centerY * zoom);
        //
        //     // Apply the transformation
        //     var matrix = ZoomBorder.Matrix;
        //     matrix = MatrixHelper.ScaleAt(zoom, zoom, 0, 0);
        //     matrix = MatrixHelper.Translate( offsetX, offsetY);
        //
        //     ZoomBorder.SetMatrix(matrix);
        // }
    }
    
   public partial class ConnectorViewModel : ObservableObject
   {
       [ObservableProperty]
       private Point _anchor;
       
       [ObservableProperty]
       private bool _isConnected;
   }
}