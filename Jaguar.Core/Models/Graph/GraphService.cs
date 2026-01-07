using System.Collections.Concurrent;

namespace Jaguar.Core.Models.Graph;

public class GraphService : IGraphService
{
    private readonly ConcurrentDictionary<string, FlowNode> _nodes = new();

    public FlowNode CreateNode(string title, NodeType type)
    {
        var node = new FlowNode
        {
            Title = title,
            Type = type
        };

        if (!_nodes.TryAdd(node.Id, node))
            throw new InvalidOperationException("Failed to add node.");

        return node;
    }

    public void RemoveNode(string nodeId)
    {
        if (!_nodes.TryRemove(nodeId, out var node))
            return;

        // Clean up connections
        foreach (var inputId in node.InputNodeIds)
            _nodes[inputId].OutputNodeIds.Remove(nodeId);

        foreach (var outputId in node.OutputNodeIds)
            _nodes[outputId].InputNodeIds.Remove(nodeId);
    }

    public void Connect(string fromNodeId, string toNodeId)
    {
        if (fromNodeId == toNodeId)
            throw new InvalidOperationException("Cannot connect node to itself.");

        var from = GetNode(fromNodeId);
        var to = GetNode(toNodeId);

        if (from.OutputNodeIds.Contains(toNodeId))
            return;

        from.OutputNodeIds.Add(toNodeId);
        to.InputNodeIds.Add(fromNodeId);
    }

    public void Disconnect(string fromNodeId, string toNodeId)
    {
        var from = GetNode(fromNodeId);
        var to = GetNode(toNodeId);

        from.OutputNodeIds.Remove(toNodeId);
        to.InputNodeIds.Remove(fromNodeId);
    }

    public FlowNode GetNode(string nodeId)
    {
        if (!_nodes.TryGetValue(nodeId, out var node))
            throw new KeyNotFoundException($"Node {nodeId} not found.");

        return node;
    }

    public IReadOnlyCollection<FlowNode> GetAllNodes() =>
        _nodes.Values as IReadOnlyCollection<FlowNode>;

    public IReadOnlyCollection<FlowNode> GetInputs(string nodeId) =>
        GetNode(nodeId)
            .InputNodeIds
            .Select(GetNode)
            .ToList();

    public IReadOnlyCollection<FlowNode> GetOutputs(string nodeId) =>
        GetNode(nodeId)
            .OutputNodeIds
            .Select(GetNode)
            .ToList();
}
