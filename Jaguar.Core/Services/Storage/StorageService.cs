using Jaguar.Core.Abstractions;
using LiteDB;
using Jaguar.Core.Models;

namespace Jaguar.Core.Services.Storage
{
    public class StorageService
    {
        private readonly string _dbPath = "JaguarData.db";

        public void SaveNodeState(DraggableNode node)
        {
            using var db = new LiteDatabase(_dbPath);
            var col = db.GetCollection<DraggableNode>("nodes");
            
            col.Upsert(node);
        }

        public IEnumerable<DraggableNode> GetAllNodes()
        {
            using var db = new LiteDatabase(_dbPath);
            return db.GetCollection<DraggableNode>("nodes").FindAll().ToList();
        }
    }
}