using System.Collections.Generic;
using Jaguar.Core.Abstractions;

namespace Jaguar.Desktop.Models.Templates;

public static class AgentTemplates
{
    public static List<FlowNode> GetAvailableAgents()
    {
         return new List<FlowNode>
        {
             new FlowNode 
{ 
    Title = "Database Architect", 
    Type = NodeType.Agent,
    Description = "Expert system for designing optimized relational and non-relational schemas. It focuses on data integrity, efficient indexing strategies, and mapping complex entity relationships for Jaguar."
},
new FlowNode 
{ 
    Title = "Security Auditor", 
    Type = NodeType.Task,
    Description = "Continuous monitoring agent that scans code and configurations for potential vulnerabilities. It ensures all logic flows comply with modern encryption standards and organizational safety rules."
},
new FlowNode 
{ 
    Title = "Translator", 
    Type = NodeType.Agent,
    Description = "Multilingual processing unit that converts linguistic data across various tongues while maintaining semantic nuances. It facilitates global communication within complex multi-agent workflows."
},
new FlowNode 
{ 
    Title = "Data Visualizer", 
    Type = NodeType.Task,
    Description = "Dynamic reporting agent that transforms raw numeric datasets into intuitive charts and graphs. It helps users identify trends and anomalies through clear, high-impact visual representations."
},
new FlowNode 
{ 
    Title = "Copywriter", 
    Type = NodeType.Agent,
    Description = "Creative content generator designed to produce compelling marketing text and technical documentation. It adapts its tone and style based on the specific audience requirements of the project."
},
new FlowNode 
{ 
    Title = "API Connector", 
    Type = NodeType.Orchestrator,
    Description = "Integration specialist that manages communication between Jaguar and external web services. It handles authentication, rate limiting, and data transformation for seamless third-party connectivity."
},
new FlowNode 
{ 
    Title = "UX Designer", 
    Type = NodeType.Agent,
    Description = "Design-thinking agent focused on wireframing and user journey mapping. It prioritizes accessibility and intuitive flow, ensuring that the final product meets high standards of usability for all."
},
new FlowNode 
{ 
    Title = "Cloud Deployer", 
    Type = NodeType.Task,
    Description = "Automated DevOps component that manages the containerization and shipping of code to various environments. It monitors deployment health and facilitates rolling updates with zero downtime."
}
        };
    }
}