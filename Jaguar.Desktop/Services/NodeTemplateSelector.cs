using Avalonia.Controls;            
using Avalonia.Controls.Templates;  
using Jaguar.Desktop.Models;

namespace Jaguar.Desktop.Services
{
    public class NodeTemplateSelector : IDataTemplate
    {
        public IDataTemplate? RegularAgentLayout { get; set; }
        public IDataTemplate? OrchestratorLayout { get; set; }
        public IDataTemplate? PmLayout { get; set; }

        public bool Match(object? data) => data is FlowNode;

        public Control? Build(object? data)
        {
            if (data is FlowNode node)
            {
                var template = node.Type switch
                {
                    NodeType.Orchestrator => OrchestratorLayout,
                    NodeType.Pm => PmLayout,
                    _ => RegularAgentLayout
                };

                // This cast is where the crash happens if the types don't match
                return template?.Build(data) as Control;
            }
            return null;
        }
    }
}