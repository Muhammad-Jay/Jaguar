namespace Jaguar.Core.Models.Templates;

public interface IAgentTemplateRepository
{
    Task<IEnumerable<AgentTemplate>> GetAll();
    Task<AgentTemplate?> GetById(string id);
    Task Add(AgentTemplate template);
    Task Update(AgentTemplate template);
    Task Delete(string id);
}
