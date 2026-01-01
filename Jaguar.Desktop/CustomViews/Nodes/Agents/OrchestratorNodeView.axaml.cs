using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Jaguar.Desktop.ViewModels;

namespace Jaguar.Desktop.CustomViews.Nodes.Agents;

public partial class OrchestratorNodeView : UserControl
{
    public OrchestratorNodeView()
    {
        InitializeComponent();
        DataContext = new WorkflowViewModel();
    }
    
    private void OnPointerPressed(object sender, PointerPressedEventArgs e)
    {
        var pointerUpdate = e.GetCurrentPoint(this);
        if (pointerUpdate.Properties.IsRightButtonPressed)
        {
            // Fetch the generic Flyout from resources
            if (Application.Current?.TryGetResource("OrchestratorContextMenu", out var res) == true 
                && res is Flyout flyout)
            {
                flyout.ShowAt(this, showAtPointer: true);
                e.Handled = true;
            }
        }
    }
}