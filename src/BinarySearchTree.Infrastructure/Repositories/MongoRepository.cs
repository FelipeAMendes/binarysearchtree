using BinarySearchTree.Core.Configs;
using MongoDB.Driver;

namespace BinarySearchTree.Infrastructure.Repositories
{
	public class MongoRepository
	{
		private readonly IMongoClient _client;
		public IMongoDatabase Database { get; }

		public MongoRepository(IDatabaseSettings settings)
		{
			var mongoUrl = MongoUrl.Create(settings.ConnectionString);

			var clientSettings = MongoClientSettings.FromUrl(mongoUrl);
			clientSettings.UseTls = false;

			_client = new MongoClient(clientSettings);
			Database = _client.GetDatabase(settings.DatabaseName ?? mongoUrl.DatabaseName);
		}
	}
}
