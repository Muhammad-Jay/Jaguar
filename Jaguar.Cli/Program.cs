using System.CommandLine;
using Jaguar.Core.Handlers;

namespace Jaguar.Cli
{
    class Program
    {
        public static async Task<int> Main(string[] args)
        {
            Command rootCommand = new RootCommand("An AI-powered tool to automate Git workflows.");
            Command runCommand = new Command("run", "Automatically analyze changes, commit, or branch based on AI decisions.");
            Command statusCommand = new Command("status", "Check the status of the current working directory.");
            
            runCommand.SetHandler(() => CommandHandlers.StartBlazorServer());
            
            rootCommand.Add(statusCommand);
            rootCommand.Add(runCommand);
            
            return await rootCommand.InvokeAsync(args);

        }
    }
}

