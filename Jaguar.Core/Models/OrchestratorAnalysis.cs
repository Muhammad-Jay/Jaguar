using System.Text.Json.Serialization;

namespace Jaguar.Core.Models;

public class OrchestratorAnalysis
{
    [JsonPropertyName("Goal")]
    public string Goal { get; set; } = string.Empty;

    [JsonPropertyName("suggestedAgents")]
    public List<string> SuggestedAgents { get; set; } = new();

    [JsonPropertyName("tasks")]
    public List<AgentTask> Tasks { get; set; } = new();
    
    [JsonPropertyName("complexityScore")]
    public int ComplexityScore { get; set; }
}