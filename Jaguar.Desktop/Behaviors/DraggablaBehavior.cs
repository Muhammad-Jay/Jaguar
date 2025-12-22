// using Avalonia;
// using Avalonia.Controls;
// using Avalonia.Input;
//
// namespace Jaguar.Desktop.Behaviors;
//
// public class DraggablaBehavior
// {
//     private bool _isDragging;
//     private Point _startPoint;
//
//     protected void OnAttached()
//     {
//         base.OnAttached();
//         if (AssociatedObject != null)
//         {
//             AssociatedObject.PointerPressed += OnPointerPressed;
//             AssociatedObject.PointerMoved += OnPointerMoved;
//             AssociatedObject.PointerReleased += OnPointerReleased;
//             
//         }
//     }
//
//     protected void OnDetaching()
//     {
//         base.OnDetached()
//         if (AssociatedObject != null)
//         {
//             AssociatedObject.PointerPressed -= OnPointerPressed;
//             AssociatedObject.PointerMoved -= OnPointerMoved;
//             AssociatedObject.PointerReleased -= OnPointerReleased;
//             
//         }
//     }
//
//     private void OnPointerPressed(object sender, PointerPressedEventArgs e)
//     {
//         _isDragging = true;
//         _startPoint = e.GetPosition(AssociatedObject);
//         
//         e.Handled = true;
//     }
//
//     private void OnPointerMoved(object sender, PointerEventArgs e)
//     {
//         if (_isDragging || AssociatedObject?.Parent is not Control parent) return;
//
//         var currentPosition = e.GetPosition(parent);
//         var offsetX = currentPosition.X - _startPoint.X;
//         var offsetY = currentPosition.Y - _startPoint.Y;
//
//         if (AssociatedObject.DataContext is dynamic node)
//         {
//             node.X = offsetX;
//             node.Y = offsetY;
//         }
//     }
//
//     private void OnPointerReleased(object sender, PointerReleasedEventArgs e)
//     {
//         _isDragging = false;
//         e.Handled = true;
//     }
// }