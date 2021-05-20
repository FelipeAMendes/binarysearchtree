namespace BinarySearchTree.Core.Helpers
{
	public class PalindromeHelper
	{
		public static bool IsPalindrome(string word)
		{
			if (string.IsNullOrWhiteSpace(word))
				return false;

			var newWord = string.Empty;
			for (int i = word.Length - 1; i >= 0; i--)
				newWord += word[i];

			return word.ToLower() == newWord.ToLower();
		}
	}
}
