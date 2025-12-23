using CommunityToolkit.Mvvm.ComponentModel;
using Jaguar.Desktop.Models;

namespace Jaguar.Desktop.ViewModels;

public partial class ConnectionViewModel : ObservableObject
{
    // The node where the wire starts
    public FlowNode Source { get; set; }

    // The node where the wire ends
    public FlowNode Target { get; set; }

    // Optional: Useful for your Orchestrator logic
    public string ConnectionType { get; set; } // e.g., "Data", "Control", "Error"
    
    public ConnectionViewModel(FlowNode source, FlowNode target)
    {
        Source = source;
        Target = target;
    }
}