using BinarySearchTree.Core.Configs;
using BinarySearchTree.Core.Entities;
using BinarySearchTree.Core.Interfaces;
using BinarySearchTree.Infrastructure.Repositories;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BinarySearchTree.Infrastructure.Interfaces
{
	public class NodeRepository : INodeRepository
    {
        private readonly IMongoCollection<Node> _nodes;

        public NodeRepository(MongoRepository mongoRepository, IDatabaseSettings settings)
        {
            _nodes = mongoRepository.Database.GetCollection<Node>(settings.NodesCollectionName);
        }

        public async Task<IEnumerable<Node>> GetNodes() =>
            await _nodes.Find(node => true).ToListAsync();

        public async Task<Node> InsertOne(Node node)
		{
            await _nodes.InsertOneAsync(node);
            return node;
        }
    }
}
