namespace Jaguar.Desktop.ViewModels
{
    public class WorkflowViewModel : ViewModelBase
    {
        public string ViewHeader => "AI Workflow Canvas - Project: Jaguar";

        public WorkflowViewModel()
        {
            // Here is where you would initialize the list of agents
            // and load the current project files from Jaguar.Core
        }
    }
}