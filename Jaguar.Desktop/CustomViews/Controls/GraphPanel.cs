using System.Collections.Specialized;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Jaguar.Desktop.ViewModels;

namespace Jaguar.Desktop.CustomViews.Controls;

public class GraphPanel : Panel
{
    protected override Size MeasureOverride(Size availableSize)
    {
        foreach (var child in Children)
        {
            child.Measure(new Size(double.MaxValue, double.MaxValue));
        }

        return new Size(5000, 5000);
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        foreach (var child in Children)
        {
            if (child is ContentPresenter { Content: FlowNodeViewModel nodeVm })
            {
                child.Arrange(new Rect(nodeVm.Location, nodeVm.Size));
            }
            else if (child.DataContext is FlowNodeViewModel vm)
            {
                child.Arrange(new Rect(vm.Location, vm.Size));
            }
            else
            {
                child.Arrange(new Rect(finalSize));
            }
        }
        return finalSize;
    }
}