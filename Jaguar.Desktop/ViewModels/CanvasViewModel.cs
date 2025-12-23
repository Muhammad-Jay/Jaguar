using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using Jaguar.Core.Abstractions;
using Jaguar.Desktop.Models;

namespace Jaguar.Desktop.ViewModels;

public partial class CanvasViewModel : ViewModelBase
{
    public ObservableCollection<FlowNode> Nodes { get; } = new()
    {
        new FlowNode { Title = "Orchestrator", Type = NodeType.Orchestrator, Location = new Point(100, 100) },
        new FlowNode { Title = "Coder", Type = NodeType.Agent, Location = new Point(400, 250) }
    };
    
    public ObservableCollection<ConnectionViewModel> Connections { get; } = new();
    
    [ObservableProperty] private object? _pendingConnection;

    public CanvasViewModel()
    {
        // Nodes.Add(new FlowNode { Title = "Orchestrator", Type = NodeType.Orchestrator, Location = new Point(100, 100) });
        // Nodes.Add(new FlowNode { Title = "Coder", Type = NodeType.Agent, Location = new Point(400, 250) });
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
            Location = new Point(x - 90, y - 50)  // Offsetting by half-height
        };
        
        Nodes.Add(newNode);

        // TODO: Add save logic.
        // SaveToDatabase(newNode);
    }
    
    public void SpawnNode(FlowNode template)
    {
        
        Nodes.Add(new FlowNode() 
        {
            Title = template.Title,
            Type = template.Type,
        });
    }
    
    public void AddLink(FlowNode from, FlowNode to)
    {
        var link = new ConnectionViewModel(from, to);
        Connections.Add(link);
        
        // TODO: Update connection to DB.
        // _db.SaveConnection(from.Id, to.Id);
    }
}