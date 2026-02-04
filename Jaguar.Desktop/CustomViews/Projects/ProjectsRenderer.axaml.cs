using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Jaguar.Core.Models;
using Jaguar.Desktop.ViewModels;

namespace Jaguar.Desktop.CustomViews.Projects;

public partial class ProjectsRenderer : UserControl
{
    public ProjectsRenderer()
    {
        InitializeComponent();
    }
    
    private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (sender is not Control control)
            return;

        if (control.DataContext is not Project project)
            return;
        
        if (e.ClickCount == 2 && DataContext is ProjectsViewModel vm)
        {
            Console.WriteLine($"Current Selected Project: {project.Id} - {project.Name}");
            vm.AppState.CurrentProject = project;
        }
    }
}