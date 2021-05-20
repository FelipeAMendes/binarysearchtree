namespace BinarySearchTree.Core.Configs
{
	public class DatabaseSettings : IDatabaseSettings
    {
        public string NodesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string NodesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
