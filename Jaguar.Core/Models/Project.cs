namespace  Jaguar.Core.Models;

public sealed class Project
{
    public string Id { get; init; } = Guid.NewGuid().ToString();
    public required string Name { get; init; } 
    
    public string? Description { get; init; }
    public required string Path { get; init; } 
    public DateTime CreatedAt { get; init; } 
    public dynamic? Manifest { get; init; }
    
}

