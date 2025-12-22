using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Xaml.Interactivity;
using Jaguar.Core.Abstractions;

namespace Jaguar.Desktop.Behaviors
{
    public class DraggableBehavior : Behavior<Control>
    {
        private bool _isDragging;
        private Point _prevPos;

        protected override void OnAttached()
        {
            base.OnAttached();
            if (AssociatedObject != null)
            {
                AssociatedObject.PointerPressed += OnPointerPressed;
                AssociatedObject.PointerMoved += OnPointerMoved;
                AssociatedObject.PointerReleased += OnPointerReleased;
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            if (AssociatedObject != null)
            {
                AssociatedObject.PointerPressed -= OnPointerPressed;
                AssociatedObject.PointerMoved -= OnPointerMoved;
                AssociatedObject.PointerReleased -= OnPointerReleased;
            }
        }

        private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            if (AssociatedObject == null || AssociatedObject.Parent is not Visual parent) return;

            _isDragging = true;
            _prevPos = e.GetPosition(parent); // Reference point on the Canvas
    
            // This stops the 'ghosting' by telling the OS to ignore other 
            // elements until the mouse is released.
            e.Pointer.Capture(AssociatedObject);
            e.Handled = true;
        }

        private void OnPointerMoved(object? sender, PointerEventArgs e)
        {
            if (!_isDragging || AssociatedObject?.Parent is not Visual parent) return;

            // Get current position relative to the Canvas
            var currentPos = e.GetPosition(parent);
    
            // Calculate how far we moved since the last frame
            var diff = currentPos - _prevPos;

            if (AssociatedObject.DataContext is IDraggableNode node)
            {
                // Smoothly increment the position
                node.X += diff.X;
                node.Y += diff.Y;
            }

            _prevPos = currentPos;
        }

        private void OnPointerReleased(object? sender, PointerReleasedEventArgs e)
        {
            _isDragging = false;
            // Release the mouse capture
            e.Pointer.Capture(null);
            e.Handled = true;
        }
    }
}