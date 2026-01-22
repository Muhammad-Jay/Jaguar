using Jaguar.Core.Models;
using Jaguar.Core.Models.Graph;

namespace Jaguar.Core.Abstractions;

public interface IProjectService
{
    List<Project> GetAllProjects();

    Project CreateProject(string name);

    List<FlowNode> GetProjectNodes(string projectName);
}