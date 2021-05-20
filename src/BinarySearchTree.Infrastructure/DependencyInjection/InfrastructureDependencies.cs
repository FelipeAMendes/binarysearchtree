using BinarySearchTree.Core.Interfaces;
using BinarySearchTree.Infrastructure.Interfaces;
using BinarySearchTree.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BinarySearchTree.Infrastructure.DependencyInjection
{
	public static class InfrastructureDependencies
	{
		public static void AddInfrastructureDependencies(this IServiceCollection services)
		{
			services.AddScoped<MongoRepository>();
			services.AddScoped<INodeRepository, NodeRepository>();
		}
	}
}
