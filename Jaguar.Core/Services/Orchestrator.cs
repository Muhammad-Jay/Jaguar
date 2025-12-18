using Jaguar.Core.Abstractions;
using Jaguar.Core.Constants;
using Jaguar.Core.Models;

namespace Jaguar.Core.Services;

public class Orchestrator
{
    private readonly IAiProvider _dispatcher;
    
    public Orchestrator(IAiProvider dispatcher)
    {
        _dispatcher = dispatcher;
    }
    
    public async Task<OrchestratorAnalysis>? InitializeProjectAsync(string prompt)
    {
        string instruction = LlmInstructions.SystemInstruction;
        
        OrchestratorAnalysis? analysis = await _dispatcher.GenerateStructuredResponseAsync(prompt, instruction);

        if (analysis != null)
        {
            Console.WriteLine($"Goal: {analysis}");
            return analysis;
        }
        else
        {
            return null;
        }
    }
}