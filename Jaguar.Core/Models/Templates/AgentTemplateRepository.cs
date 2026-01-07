using LiteDB;

namespace Jaguar.Core.Models.Templates;

public class AgentTemplateRepository : IAgentTemplateRepository, IDisposable
{
    private readonly LiteDatabase _database;
    private readonly ILiteCollection<AgentTemplate> _collection;

    public AgentTemplateRepository(string dbPath = "JaguarTemplates.db")
    {
        _database = new LiteDatabase(dbPath);
        _collection = _database.GetCollection<AgentTemplate>("agent_templates");

        // Ensure Id is unique
        _collection.EnsureIndex(x => x.Id, true);
    }

    public async Task<IEnumerable<AgentTemplate>> GetAll()
    {
        return  _collection.FindAll();
    }

    public async Task<AgentTemplate?> GetById(string id)
    {
        return  _collection.FindOne(x => x.Id == id);
    }

    public async Task Add(AgentTemplate template)
    {
         _collection.Insert(template);
    }

    public async Task Update(AgentTemplate template)
    {
         _collection.Update(template);
    }

    public async Task Delete(string id)
    {
         _collection.Delete(id);
    }

    public void Dispose()
    {
        _database.Dispose();
    }
}