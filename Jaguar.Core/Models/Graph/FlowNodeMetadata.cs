using System.Text.Json.Serialization;

namespace Jaguar.Core.Models.Graph;

public sealed class FlowNodeMetadata
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    [JsonConverter(typeof(JsonStringEnumConverter))] public NodeType Type { get; init; }
    public string Title { get; init; } = string.Empty;
}