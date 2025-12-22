using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using Jaguar.Core.Abstractions;
using Jaguar.Desktop.Models;

namespace Jaguar.Desktop.ViewModels;

public partial class CanvasViewModel : ViewModelBase
{
    [ObservableProperty] private FlowNode _rootNode;
    [ObservableProperty] private IDraggableNode _currentScope;

    public CanvasViewModel()
    {
        // 1. Create the Root (The Project Manager)
        RootNode = new FlowNode 
        { 
            Title = "Jaguar PM", 
            Type = NodeType.Orchestrator,
            X = 350, Y = 50 
        };

        // 2. Add Dummy Data (Milestones)
        var milestone1 = new FlowNode 
        { 
            Title = "Milestone 1: Backend", 
            Type = NodeType.Milestone, 
            X = 100, Y = 200 
        };
        
        var milestone2 = new FlowNode 
        { 
            Title = "Milestone 2: Frontend", 
            Type = NodeType.Milestone, 
            X = 500, Y = 200 
        };

        // 3. Add Inner Nodes (Drill Down Data)
        // Note: We must set the Parent property so 'NavigateUp' works!
        
        // Inside Milestone 1
        AddChild(milestone1, new FlowNode { Title = "Database Agent", Type = NodeType.Agent, X = 50, Y = 100 });
        AddChild(milestone1, new FlowNode { Title = "Auth Service", Type = NodeType.Agent, X = 250, Y = 100 });

        // Inside Milestone 2
        AddChild(milestone2, new FlowNode { Title = "UI Layout", Type = NodeType.Agent, X = 50, Y = 100 });
        AddChild(milestone2, new FlowNode { Title = "Theme Manager", Type = NodeType.Agent, X = 250, Y = 100 });

        // 4. Attach Milestones to Root
        AddChild(RootNode, milestone1);
        AddChild(RootNode, milestone2);

        // 5. Initialize Scope
        CurrentScope = RootNode;
    }

    // Helper to ensure Parent/Child relationship is linked both ways
    private void AddChild(FlowNode parent, FlowNode child)
    {
        child.Parent = parent; // Crucial for NavigateUp()
        parent.Children.Add(child);
    }

    public void NavigateDown(FlowNode node)
    {
        if (node.Children.Any())
        {
            CurrentScope = node;
        }
    }

    public void NavigateUp()
    {
        if (CurrentScope.Parent != null)
        {
            CurrentScope = CurrentScope.Parent;
        }
    }
    
    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);
    
        // If a node moves or a child is added, trigger a background save
        if (e.PropertyName == nameof(CurrentScope) || e.PropertyName == "X" || e.PropertyName == "Y")
        {
            SaveProject();
        }
    }
    
    private void SaveProject()
    {
        // var json = JsonSerializer.Serialize(this.RootNode, new JsonSerializerOptions { WriteIndented = true });
        // File.WriteAllText(Path.Combine(ProjectDirectory, "project.jaguar"), json);
    }
    
    public void AddNewNodeFromTemplate(FlowNode template, double x, double y)
    {
        var newNode = new FlowNode 
        { 
            Title = template.Title, 
            Type = template.Type,
            X = x - 90, // Offsetting by half-width to center on cursor
            Y = y - 50  // Offsetting by half-height
        };
        
        CurrentScope.Children.Add(newNode);

        // TODO: Add save logic.
        // SaveToDatabase(newNode);
    }
}