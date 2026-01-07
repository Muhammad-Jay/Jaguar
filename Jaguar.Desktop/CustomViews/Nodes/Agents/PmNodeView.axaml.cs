using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using Avalonia.VisualTree;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.ViewModels;

namespace Jaguar.Desktop.CustomViews.Nodes.Agents;

public partial class PmNodeView : UserControl
{
    private bool _anchorUpdateQueued;
    public PmNodeView()
    {
        InitializeComponent();
        
        this.AttachedToVisualTree += (_, __) =>
        {
            QueueAnchorUpdate();

            var editor = this.FindAncestorOfType<Nodify.NodifyEditor>();
            if (editor != null)
                editor.ViewportUpdated += (_, __) => QueueAnchorUpdate();
        };
    }
    
    private void QueueAnchorUpdate()
    {
        if (!IsVisible || !this.IsAttachedToVisualTree())
            return;

        Dispatcher.UIThread.Post(UpdateAnchors, DispatcherPriority.Render);
    }
    
    private void OnPointerPressed(object sender, PointerPressedEventArgs e)
    {
        if (e.GetCurrentPoint(this).Properties.IsRightButtonPressed)
        {
            // If you are using the property approach, you don't even need this.
            // But if you want to be 100% sure:
            this.ContextMenu?.Open(this);
            e.Handled = true; // This prevents the parent ItemContainer from opening ITS menu
        }
    }
    
    private void UpdateAnchors()
    {
        if (DataContext is not FlowNodeViewModel vm)
            return;

        var editor = this.FindAncestorOfType<Nodify.NodifyEditor>();
        if (editor == null)
            return;

        foreach (var input in vm.Inputs)
            UpdateAnchor(input.Anchor, InputAnchorControl, editor);

        foreach (var output in vm.Outputs)
            UpdateAnchor(output.Anchor, OutputAnchorControl, editor);
    }

    private static void UpdateAnchor(
        Anchor anchor,
        Control anchorControl,
        Nodify.NodifyEditor editor)
    {
        if (!anchorControl.IsVisible)
            return;
    
        if (anchorControl.Bounds.Width <= 0 ||
            anchorControl.Bounds.Height <= 0)
            return;
    
        var presenter = editor.Presenter;
        if (presenter == null)
            return;
    
        var transform = anchorControl.TransformToVisual(presenter);
        if (transform == null)
            return;
    
        var center = new Point(
            anchorControl.Bounds.Width / 2,
            anchorControl.Bounds.Height / 2);
    
        var newPos = transform.Value.Transform(center);
    
        if (anchor.Position != newPos)
            anchor.Position = newPos;
    }
}