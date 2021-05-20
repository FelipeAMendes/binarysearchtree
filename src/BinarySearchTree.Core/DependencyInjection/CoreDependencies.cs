using BinarySearchTree.Core.Configs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BinarySearchTree.Infrastructure.DependencyInjection
{
	public static class CoreDependencies
	{
		public static void AddCoreDependencies(this IServiceCollection services)
		{
			services.AddSingleton<IDatabaseSettings>(p => p.GetRequiredService<IOptions<DatabaseSettings>>().Value);
		}
	}
}
