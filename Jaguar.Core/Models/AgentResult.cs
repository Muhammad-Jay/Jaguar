using System.Text.Json.Serialization;

namespace Jaguar.Core.Models;

public class AgentResult
{
    [JsonPropertyName("task_id")]
    public Guid TaskId { get; set; }

    [JsonPropertyName("is_success")]
    public bool IsSuccess { get; set; }

    /// <summary>
    /// Categorizes the output so the UI or Core logic knows how to handle it.
    /// </summary>
    [JsonPropertyName("output_type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public JaguarOutputType OutputType { get; set; }

    /// <summary>
    /// The actual payload (e.g., the code, the plan, or the raw text).
    /// </summary>
    [JsonPropertyName("output_payload")]
    public string OutputPayload { get; set; }

    [JsonPropertyName("observations")]
    public string Observations { get; set; }

    [JsonPropertyName("error_message")]
    public string? ErrorMessage { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, string> Metadata { get; set; } = new();
}

public enum JaguarOutputType
{
    RawText,        // Simple conversational response
    Markdown,       // Formatted documentation or reports
    SourceCode,     // C#, Python, etc.
    ShellScript,    // Bash/Terminal commands for Zorin OS
    JsonData,       // Structured data for internal processing
    SystemDiagram,  // Mermaid or PlantUML strings
    Plan            // A list of sub-tasks for the PM
}