using Jaguar.Core.Abstractions;
using LiteDB;
using Jaguar.Core.Models;

namespace Jaguar.Core.Services.Storage
{
    public class StorageService
    {
        private readonly string _dbPath = "JaguarData.db";

        public void SaveNodeState(IDraggableNode node)
        {
            // The 'using' statement ensures the file is closed after writing
            using var db = new LiteDatabase(_dbPath);
            var col = db.GetCollection<IDraggableNode>("nodes");
            
            // Upsert will update if the ID exists, or insert if it's new
            col.Upsert(node);
        }

        public IEnumerable<IDraggableNode> GetAllNodes()
        {
            using var db = new LiteDatabase(_dbPath);
            return db.GetCollection<IDraggableNode>("nodes").FindAll().ToList();
        }
    }
}