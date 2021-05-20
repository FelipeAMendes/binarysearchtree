using BinarySearchTree.Core.Configs;
using BinarySearchTree.Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BinarySearchTree.IntegrationTests.Util
{
	public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
	{
		protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			IConfiguration configuration = null;

			builder
				.ConfigureAppConfiguration(webHost =>
				{
					configuration = webHost
						.AddJsonFile("appsettings.Tests.json")
						.Build();

				}).ConfigureServices(services =>
				{
					services.Configure<DatabaseSettings>(configuration.GetSection(nameof(DatabaseSettings)));
					services.AddCoreDependencies();
					services.AddInfrastructureDependencies();
				});
		}
	}
}
