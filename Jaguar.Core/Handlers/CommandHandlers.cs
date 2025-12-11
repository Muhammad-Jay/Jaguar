using System.Diagnostics;

namespace Jaguar.Core.Handlers
{
    public static class CommandHandlers
    {
        public static async Task StartBlazorServer()
        {
            string command = "dotnet";
            string arguments = "run";

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = command, 
                    Arguments = arguments,
                    CreateNoWindow = true,
                    UseShellExecute = true, 
                    WorkingDirectory = "../Jaguar.WebUi/" 
                };
            
                using (Process? process = Process.Start(startInfo))
                {
                    if (process == null)
                    {
                        Console.WriteLine("[Error] Could not start the process. Check if the command is installed.");
                        return;
                    }
                
                    Console.WriteLine($"\n[Success] Server command executed with PID: {process.Id}");
                    Console.WriteLine("The server is now running in the background. Press Ctrl+C to exit this CLI.");
                    Console.WriteLine("To stop the server, you may need to find the process ID (PID) and terminate it manually.");
                   
                    process.WaitForExit(); 
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}