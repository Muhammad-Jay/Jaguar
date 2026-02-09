using Avalonia.Controls;            
using Avalonia.Controls.Templates;
using Jaguar.Core.Models.Graph;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.ViewModels;

namespace Jaguar.Desktop.Services
{
    public class NodeTemplateSelector : IDataTemplate
    {
        public IDataTemplate? RegularAgentLayout { get; set; }
        public IDataTemplate? OrchestratorLayout { get; set; }
        public IDataTemplate? PmLayout { get; set; }

        public bool Match(object? data) => data is FlowNodeViewModel;

        public Control? Build(object? data)
        {
            if (data is FlowNodeViewModel node)
            {
                var template = node.Type switch
                {
                    NodeType.Orchestrator => OrchestratorLayout,
                    _ => PmLayout
                };
                
                return template?.Build(data) as Control;
            }
            return null;
        }
    }
}