using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using Jaguar.Desktop.Models;
using Nodify;

namespace Jaguar.Desktop.CustomViews.Connector;

public partial class ConnectorView : UserControl
{
    public ConnectorView()
    {
        InitializeComponent();
        this.DataContextChanged += OnDataContextChanged;
        this.Loaded += (s, e) => UpdateAnchorPosition();
        this.AttachedToVisualTree += (s, e) => UpdateAnchorPosition();
        this.LayoutUpdated += (s, e) => UpdateAnchorPosition();
    }

    private void OnDataContextChanged(object? sender, EventArgs e)
    {
        // if (DataContext is ConnectorViewModel vm && vm.ParentNode != null)
        // {
        //     // vm.ParentNode.PropertyChanged += (s, args) =>
        //     // {
        //     //     if (args.PropertyName == "Location")
        //     //     {
        //     //         UpdateAnchorPosition();;
        //     //     }
        //     // };
        // }
    }

    private void UpdateAnchorPosition()
    {
        if (DataContext is ConnectorViewModel vm)
        {
            var canvas = this.FindAncestorOfType<NodifyEditor>();
            if (canvas == null) return;
            
            var centerPoint = new Point(this.Bounds.Width / 2, this.Bounds.Height / 2);
            var relativePoint = this.TranslatePoint(centerPoint, canvas);

            if (relativePoint.HasValue)
            {
                vm.Anchor.Position = relativePoint.Value;
            }
        }
    }
}