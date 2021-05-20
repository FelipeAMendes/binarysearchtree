using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BinarySearchTree.Core.Entities
{
	public class Node
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public int Key { get; set; }
		public Node Left { get; set; }
		public Node Right { get; set; }

		public Node(int key)
		{
			Key = key;
			Left = Right = null;
		}

		public Node FindWithValue(int key)
		{
			var currentKey = Key;
			if (currentKey == key)
				return this;

			if (currentKey < key)
				return Right is null ? Right : Right.FindWithValue(key);

			return Left is null ? Left : Left.FindWithValue(key);
		}
	}
}
