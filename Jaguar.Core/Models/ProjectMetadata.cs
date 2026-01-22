using System.Text.Json.Serialization;

namespace Jaguar.Core.Models;

public sealed class ProjectMetadata
{
    [JsonPropertyName("id")] public Guid Id { get; init; } = Guid.NewGuid();
    [JsonPropertyName("name")] public required string Name { get; init; } = string.Empty;
    [JsonPropertyName("description")] public string? Description { get; init; }
    [JsonPropertyName("schemaVersion")] public int SchemaVersion { get; init; } = 1;
    
    [JsonPropertyName("jaguarVersion")] public string? JaguarVersion { get; init; }
    [JsonPropertyName("createdAt")] public DateTime CreatedAt { get; init; }
    [JsonPropertyName("lastModified")] public DateTime LastModified { get; set; }
}