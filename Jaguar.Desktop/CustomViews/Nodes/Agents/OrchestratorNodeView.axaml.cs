using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Jaguar.Desktop.ViewModels;

namespace Jaguar.Desktop.CustomViews.Nodes.Agents;

public partial class OrchestratorNodeView : UserControl
{
    public OrchestratorNodeView()
    {
        InitializeComponent();
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
}