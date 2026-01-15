using System;
using System.Diagnostics;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.VisualTree;
using Jaguar.Desktop.CustomViews.Controls;
using Jaguar.Desktop.ViewModels;
using Jaguar.Desktop.Views;
using ReactiveUI;

namespace Jaguar.Desktop.CustomViews.Nodes.Agents;

public partial class OrchestratorNodeView : UserControl
{
    private Point _dragStart;
    private Point _nodeStart;
    private bool _isDragging;

    public OrchestratorNodeView()
    {
        InitializeComponent();
    }
    
    private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (DataContext is not FlowNodeViewModel vm) return;

        var canvasVm = this.FindAncestorOfType<CanvasView>()?.DataContext as CanvasViewModel;
        if (canvasVm == null) return;

        // Check if Ctrl or Shift is held for multi-select
        bool isMulti = e.KeyModifiers.HasFlag(KeyModifiers.Control) ||
                       e.KeyModifiers.HasFlag(KeyModifiers.Shift);

        canvasVm.SetSelection(vm, isMulti);

        var graphPanel = this.GetVisualAncestors().OfType<GraphPanel>().FirstOrDefault();
        if (graphPanel == null) return;

        _isDragging = true;
        
        _dragStart = e.GetPosition(graphPanel);
        _nodeStart = vm.Location;

        // e.Pointer.Capture(this);
        e.Handled = true;
        
        UpdatePopupPosition();
    }
    
    private void OnPointerMoved(object? sender, PointerEventArgs e)
    {
        if (!_isDragging || DataContext is not FlowNodeViewModel vm) return;

        var graphPanel = this.GetVisualAncestors().OfType<GraphPanel>().FirstOrDefault();
        if (graphPanel == null) return;

        var currentMousePos = e.GetPosition(graphPanel);
        var delta = currentMousePos - _dragStart;

        var canvasVm = this.FindAncestorOfType<CanvasView>()?.DataContext as CanvasViewModel;

        if (vm.IsSelected && canvasVm?.SelectedNodes.Count > 1)
        {
            foreach (var selectedNode in canvasVm.SelectedNodes)
            {
                selectedNode.Location = new Point(
                    selectedNode.Location.X + delta.X,
                    selectedNode.Location.Y + delta.Y);
            }
            _dragStart = currentMousePos; // Update start for the next delta
        }
        else
        {
            // Normal single-node drag
            vm.Location = new Point(_nodeStart.X + delta.X, _nodeStart.Y + delta.Y);
        }

        // Tell the panel it needs to re-arrange its children immediately
        graphPanel.InvalidateArrange();
        UpdatePopupPosition();
    }

    private void OnPointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        if (!_isDragging) return;
        
        _isDragging = false;
        // e.Pointer.Capture(null);
        e.Handled = true;

        UpdatePopupPosition();
    }

    // private void PointerOver(object? sender, PointerEventArgs e)
    // {
    //     
    // }

    private void UpdatePopupPosition()
    {
        // if (NodeMenuPopup.IsOpen)
        // {
        //     var point = this.PointToScreen(new Point(
        //         this.Bounds.X, this.Bounds.Y
        //     ));
        //
        //     NodeMenuPopup.HorizontalOffset = point.X;
        //     NodeMenuPopup.VerticalOffset = point.Y;
        // }
    }
    
    // private void OnPointerPressed(object sender, PointerPressedEventArgs e)
    // {
    //     if (e.GetCurrentPoint(this).Properties.IsRightButtonPressed)
    //     {
    //         this.ContextMenu?.Open(this);
    //         e.Handled = true; 
    //     }
    // }
}