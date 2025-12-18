using System.Text.Json.Serialization;

namespace Jaguar.Core.Models;

public enum TaskStatus { Pending, InProgress, Completed, Failed, NeedsReview }

public class AgentTask
{
    // [JsonPropertyName("id")]
    // public Guid Id { get; set; } = Guid.NewGuid();

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
    
    [JsonPropertyName("requirements")]
    public List<string> Requirements { get; set; } = new();

    [JsonPropertyName("constraints")]
    public List<string> Constraints { get; set; } = new();
    
    [JsonPropertyName("contextData")] // Use snake_case or camelCase consistently
    public Dictionary<string, string> ContextData { get; set; } = new();
    
    [JsonPropertyName("status")]
    [JsonConverter(typeof(JsonStringEnumConverter))] // Important: Serialize as "Pending" not 0
    public TaskStatus Status { get; set; } = TaskStatus.Pending;
}