using System.Collections.Generic;
using Jaguar.Core.Abstractions;

namespace Jaguar.Desktop.Models.Templates;

public static class AgentTemplates
{
    public static List<FlowNode> GetAvailableAgents()
    {
        return new List<FlowNode>
        {
            new FlowNode { Title = "PM Orchestrator", Type = NodeType.Orchestrator },
            new FlowNode { Title = "Milestone Planner", Type = NodeType.Milestone },
            new FlowNode { Title = "Python Coder", Type = NodeType.Agent },
            new FlowNode { Title = "Research Agent", Type = NodeType.Agent },
            new FlowNode { Title = "3D Modeler", Type = NodeType.Agent },
            new FlowNode { Title = "Validator", Type = NodeType.Task },
            new FlowNode { Title = "Reviewer", Type = NodeType.Task }
        };
    }
}