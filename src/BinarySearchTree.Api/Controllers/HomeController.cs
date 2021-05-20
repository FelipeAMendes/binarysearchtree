using BinarySearchTree.Core.Catalog;
using BinarySearchTree.Core.Entities;
using BinarySearchTree.Core.Helpers;
using BinarySearchTree.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BinarySearchTree.Api.Controllers
{
	[ApiController]
	[Route("api/")]
	[Produces("application/json", "application/problem+json")]
	public class HomeController : ControllerBase
	{
		private readonly INodeRepository _nodeRepository;

		public HomeController(INodeRepository nodeRepository)
		{
			_nodeRepository = nodeRepository;
		}

		/// <summary>
		/// Check if a word is palindrome
		/// </summary>
		/// <param name="term">word to check</param>
		/// <returns>isPalindrome: true or false</returns>
		[HttpGet("/is-palindrome/{term}")]
		public IActionResult IsPalindrome(string term)
		{
			var isPalindrome = PalindromeHelper.IsPalindrome(term);
			return Ok(ResultApi<bool>.Create(true, message: null, isPalindrome));
		}

		/// <summary>
		/// Search in the tree
		/// </summary>
		/// <remarks>
		/// Search in the tree below if there is a certain value in it
		/// 
		/// - N1 (Value: 1, Left: null, Right: null)
		/// - N2 (Value: 2, Left: N1, Right: N3)
		/// - N3 (Value: 3, Left: null, Right: null)
		/// 
		/// </remarks>
		/// <param name="value">value to search</param>
		/// <returns>Which node has the given value</returns>
		[HttpGet("/search/{value:int}")]
		public async Task<IActionResult> Search(int value)
		{
			var node = (await _nodeRepository.GetNodes()).LastOrDefault();
			var result = node?.FindWithValue(value);
			return Ok(ResultApi<int>.Create(true, message: null, result?.Key ?? -1));
		}

		/// <summary>
		/// Method to save the node to the Mongo database
		/// </summary>
		/// <returns>Node added: true or false</returns>
		[HttpPost("/create-nodes")]
		public async Task<IActionResult> AddNodesInDatabase()
		{
			Node n1 = new(1);
			Node n3 = new(3);
			Node nRoot = new(2)
			{
				Key = 2,
				Left = n1,
				Right = n3
			};

			var node = await _nodeRepository.InsertOne(nRoot);

			var nodeAdded = node.Key > 0;
			var message = nodeAdded
				? NodeMessages.SaveSuccess
				: NodeMessages.SaveError;

			return Ok(ResultApi<string>.Create(nodeAdded, message));
		}
	}
}
