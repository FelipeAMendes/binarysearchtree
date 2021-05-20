using BinarySearchTree.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BinarySearchTree.Core.Interfaces
{
	public interface INodeRepository
	{
		Task<IEnumerable<Node>> GetNodes();
		Task<Node> InsertOne(Node node);
	}
}
