using BinarySearchTree.Core.Helpers;
using Xunit;

namespace BinarySearchTree.UnitTests
{
	public class PalindromeUnitTest
	{
		[Fact]
		public void IsPalindrome_WordIsNull_ReturnFalse()
		{
			const string term = null;

			var result = PalindromeHelper.IsPalindrome(term);

			Assert.False(result);
		}

		[Fact]
		public void IsPalindrome_WordIsPalindrome_ReturnTrue()
		{
			const string term = "deleveled";

			var result = PalindromeHelper.IsPalindrome(term);

			Assert.True(result);
		}

		[Fact]
		public void IsPalindrome_WordIsNotPalindrome_ReturnFalse()
		{
			const string term = "Something";

			var result = PalindromeHelper.IsPalindrome(term);

			Assert.False(result);
		}

		[Fact]
		public void IsPalindrome_WordWithSomeCapitalLetters_ReturnTrue()
		{
			const string term = "DeLeveLEd";

			var result = PalindromeHelper.IsPalindrome(term);

			Assert.True(result);
		}

		[Fact]
		public void IsPalindrome_CapitalizedWord_ReturnTrue()
		{
			const string term = "DELEVELED";

			var result = PalindromeHelper.IsPalindrome(term);

			Assert.True(result);
		}
	}
}
