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
    public CanvasView()
    {
        InitializeComponent();
        if (Program.AppHost != null)
        {
            DataContext = Program.AppHost.Services.GetRequiredService<CanvasViewModel>();
            var canvas = this.FindControl<ItemsControl>("NodeCanvas");
            if (canvas != null)
            {
                DragDrop.SetAllowDrop(canvas, true);
                canvas.AddHandler(DragDrop.DropEvent, OnDrop);
            }
        }
    }
    
    private void OnDrop(object? sender, DragEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("Drop detected!");
        // 1. Extract the template data
        if (e.Data.Get("AgentTemplate") is FlowNode template)
        {
            e.DragEffects = DragDropEffects.Copy;
            // 2. Get the mouse position relative to THIS canvas
            var dropPos = e.GetPosition(this.FindControl<ItemsControl>("NodeCanvas"));

            // 3. Notify the ViewModel
            if (DataContext is CanvasViewModel vm)
            {
                // We pass the template and the coordinates
                vm.AddNewNodeFromTemplate(template, dropPos.X, dropPos.Y);
                System.Diagnostics.Debug.WriteLine($"Data found: {e.Data.Get("AgentTemplate") != null}");
            }
        }
    }
}