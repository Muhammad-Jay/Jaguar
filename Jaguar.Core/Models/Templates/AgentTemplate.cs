using Jaguar.Core.Models.Graph;

namespace Jaguar.Core.Models.Templates;

public class AgentTemplate
{
    public string Id { get; init; } = Guid.NewGuid().ToString();

    public required string Title { get; init; }
    public required NodeType Type { get; init; }

    public string Description { get; init; } = string.Empty;
    public string SystemInstruction { get; init; } = string.Empty;
}
