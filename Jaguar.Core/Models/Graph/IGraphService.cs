namespace Jaguar.Core.Models.Graph;

public interface IGraphService
{
    FlowNode CreateNode(string title, NodeType type);
    void RemoveNode(string nodeId);

    void Connect(string fromNodeId, string toNodeId);
    void Disconnect(string fromNodeId, string toNodeId);

    FlowNode GetNode(string nodeId);
    IReadOnlyCollection<FlowNode> GetAllNodes();

    IReadOnlyCollection<FlowNode> GetInputs(string nodeId);
    IReadOnlyCollection<FlowNode> GetOutputs(string nodeId);
}