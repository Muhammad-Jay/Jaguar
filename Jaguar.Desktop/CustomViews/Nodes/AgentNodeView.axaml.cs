using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.CustomViews.Nodes;

public partial class AgentNodeView : UserControl
{
    public AgentNodeView()
    {
        InitializeComponent();
    }
    
    public void OnDoubleTapped(object sender, TappedEventArgs e)
    {
        if (this.DataContext is FlowNode node)
        {
            // 1. Check if the node has children
            if (node.Children.Any())
            {
                if (Program.AppHost != null)
                {
                    // 2. Get your ViewModel from the Service Provider
                    var canvasVM = Program.AppHost.Services.GetRequiredService<CanvasViewModel>();
                
                    // 3. Trigger the navigation
                    // canvasVM.NavigateDown(node);
                }
            }
        }
    }
}