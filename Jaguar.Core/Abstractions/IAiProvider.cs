using Jaguar.Core.Models;

namespace Jaguar.Core.Abstractions;

public interface IAiProvider
{
    // The Core only cares about getting a result back, not how Gemini works.
    Task<OrchestratorAnalysis> GenerateStructuredResponseAsync(string userPrompt, string instructions);
}