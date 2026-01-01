using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using Jaguar.Desktop.Models;

namespace Jaguar.Desktop.CustomViews.Connector;

public partial class ConnectorView : UserControl
{
    public ConnectorView()
    {
        InitializeComponent();
        
        this.LayoutUpdated += (s, e) => UpdateAnchorPosition();
    }

    private void UpdateAnchorPosition()
    {
        if (DataContext is ConnectorViewModel vm)
        {
            var canvas = this.FindAncestorOfType<Canvas>();
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