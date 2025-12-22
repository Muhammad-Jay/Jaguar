using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.ViewModels;

namespace Jaguar.Desktop.CustomViews.Nodes;

public partial class AgentNodeView : UserControl
{
    public AgentNodeView()
    {
        InitializeComponent();
    }
    
    public void OnDoubleTapped(object sender, TappedEventArgs e)
    {
        if (DataContext is FlowNode node && node.Children.Any())
        {
            // Reach up to the CanvasViewModel to trigger navigation
            // Note: You can also use a Message Bus (CommunityToolkit.Mvvm.Messaging)
            var topLevel = this.VisualRoot as Window;
            if (topLevel?.DataContext is WorkflowViewModel mainVM)
            {
                // mainVM.CanvasViewModel.NavigateDown(node);
            }
        }
    }

    // private void OnDoubleTapped(object? sender, RoutedEventArgs e)
    // {
    //     if (DataContext is FlowNode node)
    //     {
    //         
    //     }
    // }
}