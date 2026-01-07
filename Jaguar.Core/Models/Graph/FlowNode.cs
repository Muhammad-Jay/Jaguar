using System;
using System.Collections.Generic;

namespace Jaguar.Core.Models.Graph;

public class FlowNode
{
    // Identity
    public string Id { get; set; } = Guid.NewGuid().ToString();

    // Classification
    public NodeType Type { get; set; }

    // Semantics
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Cognition
    public string SystemInstruction { get; set; } = string.Empty;
    public CognitiveState State { get; set; } = CognitiveState.Pending;
    public double Confidence { get; set; } = 0.0;

    // Visibility / Control
    public bool IsInternal { get; set; } = false;

    // Graph Structure (PURE REFERENCES)
    public string? ParentId { get; set; }
    public List<string> ChildrenIds { get; set; } = new();
    
    // 🔹 Cognitive graph relationships
    public List<string> InputNodeIds { get; } = new();
    public List<string> OutputNodeIds { get; } = new();

    // Metadata (optional, future-proof)
    public Dictionary<string, object> Metadata { get; set; } = new();
}

public enum CognitiveState
{
    Pending,
    Thinking,
    Simulating,
    Executing,
    Evaluating,
    Reflecting,
    Completed,
    Failed
}

public enum NodeType
{
    // Executive Layer
    Orchestrator,
    ProjectManager,

    // Intent & Planning
    Intent,
    Goal,
    Plan,

    // Reasoning Layer
    Reasoning,
    Hypothesis,
    Constraint,

    // Simulation Layer
    Simulation,
    Scenario,
    Risk,

    // Execution Layer
    Agent,
    Task,
    Tool,

    // Evaluation Layer
    Evaluation,
    Reflection,
    Decision,

    // Memory Layer
    Memory,
    Belief,
    Knowledge
}