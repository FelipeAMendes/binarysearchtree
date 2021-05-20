using BinarySearchTree.Api;
using BinarySearchTree.IntegrationTests.Util;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace BinarySearchTree.IntegrationTests
{
	public class IntegrationTest : IClassFixture<CustomWebApplicationFactory<Startup>>
	{
		private readonly HttpClient _httpClient;
		private readonly CustomWebApplicationFactory<Startup> _webApplicationFactory;

		public IntegrationTest(CustomWebApplicationFactory<Startup> webApplicationFactory)
		{
			_webApplicationFactory = webApplicationFactory;

			_webApplicationFactory = webApplicationFactory;
			_httpClient = _webApplicationFactory.CreateClient();
		}

		[Theory]
		[InlineData("http://localhost:45239/swagger/index.html")]
		[InlineData("http://localhost:45239/is-palindrome/aea")]
		[InlineData("http://localhost:45239/search/2")]
		public async Task Get_Endpoints_ReturnSuccess(string url)
		{
			var response = await _httpClient.GetAsync(url);

			response.EnsureSuccessStatusCode();
		}

		[Fact]
		public async Task Post_EndpointAddNodeInDatabase_ReturnSuccess()
		{
			const string url = "http://localhost:45239/create-nodes";

			var response = await _httpClient.PostAsync(url, null);
			response.EnsureSuccessStatusCode();
			var responseString = await response.Content.ReadAsStringAsync();
			dynamic jsonObject = JObject.Parse(responseString);
			bool result = (bool)jsonObject.success;

			Assert.True(result);
		}
	}
}
