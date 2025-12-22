using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.Views;

public partial class CanvasView : UserControl
{
    private bool _isDragging;
    private Point _pointerOffset;
    private Control? _draggedElement;
    
    public CanvasView()
    {
        InitializeComponent();
        if (Program.AppHost != null)
        {
            DataContext = Program.AppHost.Services.GetRequiredService<CanvasViewModel>();
        }
    }
    
    private void OnPointerPressed(object sender, PointerPressedEventArgs e)
    {
        _isDragging = true;
        _draggedElement = sender as Control;
        _pointerOffset = e.GetPosition(_draggedElement);
        e.Pointer.Capture(_draggedElement);
        e.Handled = true;
    }

    private void OnPointerMoved(object sender, PointerEventArgs e)
    {
        if (_isDragging && _draggedElement?.DataContext is FlowNode node)
        {
            var currentPosition = e.GetPosition(this);
            var offsetX = currentPosition.X - _pointerOffset.X;
            var offsetY = currentPosition.Y - _pointerOffset.Y;

      
            node.X = offsetX;
            node.Y = offsetY;
        }
    }

    private void OnPointerReleased(object sender, PointerReleasedEventArgs e)
    {
        _isDragging = false;
        _draggedElement = null;
        e.Pointer.Capture(null);
    }
}