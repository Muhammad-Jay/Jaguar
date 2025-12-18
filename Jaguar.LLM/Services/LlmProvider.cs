using GenerativeAI;
using GenerativeAI.Types;
using Jaguar.Core.Abstractions;
using Jaguar.Core.Models;
using Microsoft.Extensions.Options;

namespace Jaguar.LLM.Services;

public class LlmProvider: IAiProvider
{
    public readonly GoogleAi Provider;
    private readonly string _apiKey;

    public LlmProvider(IOptions<GeminiConfig> options)
    {
        _apiKey = options.Value.ApiKey;

        if (_apiKey == null)
        {
            Console.WriteLine("Missing API Key");
            throw new ArgumentNullException(nameof(_apiKey));
        }
        Provider = new GoogleAi(_apiKey);
    }

    public async Task<OrchestratorAnalysis>? GenerateStructuredResponseAsync(string prompt, string? systemInstruction)
    {
        try
        {
            var model = Provider.CreateGenerativeModel("models/gemini-2.5-flash");
            var request = new GenerateContentRequest();
        
            request.UseJsonMode<OrchestratorAnalysis>();
            request.GenerationConfig = new GenerationConfig()
            {
                ResponseMimeType = "application/json"
            };
            
            request.AddText($"{systemInstruction}\n {prompt}");
        
            var response = await model.GenerateContentAsync(request);
            
            var jsonString = response.ToObject<OrchestratorAnalysis>();
            Console.WriteLine($"Raw AI Response: {jsonString}");
            
            // var jsonObject = System.Text.Json.JsonSerializer.Deserialize<OrchestratorAnalysis>(jsonString, new System.Text.Json.JsonSerializerOptions
            // {
            //     PropertyNameCaseInsensitive = true
            // });
            return jsonString;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }

    }
}