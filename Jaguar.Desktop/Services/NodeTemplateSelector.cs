using System;
using Avalonia.Controls;              // Provides 'Control'
using Avalonia.Controls.Templates;    // Provides 'IDataTemplate'
using Avalonia.Markup.Xaml.Templates; // Provides 'DataTemplate'
using Jaguar.Core.Models;
using Jaguar.Desktop.Models; // Provides 'FlowNode' and 'NodeType'

namespace Jaguar.Desktop.Services
{
    public class NodeTemplateSelector : IDataTemplate
    {
        public IDataTemplate? RegularAgentLayout { get; set; }
        public IDataTemplate? OrchestratorLayout { get; set; }
        public IDataTemplate? PmLayout { get; set; }

        public bool Match(object? data) => data is FlowNode;

        public Control? Build(object? param)
        {
            if (param is FlowNode node)
            {
                return node.Type switch
                {
                    NodeType.Orchestrator => OrchestratorLayout?.Build(param),
                    NodeType.Agent        => RegularAgentLayout?.Build(param),
                    NodeType.Pm          => PmLayout?.Build(param),
                    _                     => RegularAgentLayout?.Build(param)
                };
            }
            return null;
        }
    }
}