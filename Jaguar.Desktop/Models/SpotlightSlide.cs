using System;

namespace Jaguar.Desktop.Models;

public sealed class SpotlightSlide
{
    public string Id { get; init; } = Guid.NewGuid().ToString();

    public string Title { get; init; } = string.Empty;
    
    public string? SubTitle { get; init; }

    public string VisualSource { get; init; } = string.Empty;

    public TimeSpan Duration { get; init; } = TimeSpan.FromSeconds(10);
}