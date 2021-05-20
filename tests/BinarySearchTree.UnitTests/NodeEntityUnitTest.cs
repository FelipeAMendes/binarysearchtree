using BinarySearchTree.Core.Entities;
using System;
using Xunit;

namespace BinarySearchTree.UnitTests
{
	public class NodeEntityUnitTest
	{
		private readonly Node nodeTest;

		public NodeEntityUnitTest()
		{
			Node n1 = new(1);
			Node n3 = new(3);
			nodeTest = new(2)
			{
				Key = 2,
				Left = n1,
				Right = n3
			};
		}

		[Fact]
		public void FindWithValue_KeyToFindIsEqualsCurrentKey_ReturnKey()
		{
			const int key = 2;

			var result = nodeTest.FindWithValue(key);

			Assert.Equal(key, result.Key);
		}

		[Fact]
		public void FindWithValue_KeyToFindIsSmallerThanCurrentKey_ReturnSmaller()
		{
			const int key = 3;

			var result = nodeTest.FindWithValue(key);

			Assert.Equal(key, result.Key);
		}

		[Fact]
		public void FindWithValue_KeyToFindIsGreaterThanCurrentKey_ReturnGreater()
		{
			const int key = 3;

			var result = nodeTest.FindWithValue(key);

			Assert.Equal(key, result.Key);
		}

		[Fact]
		public void FindWithValue_KeyToBeFoundDoesNotExist_ReturnNull()
		{
			const int key = 7;

			var result = nodeTest.FindWithValue(key);

			Assert.Null(result);
			Assert.NotEqual(key, result?.Key);
		}

		[Fact]
		public void NodeEntity_SetValues_ReturnNodeEntity()
		{
			Node n1 = new(1);
			Node n3 = new(3);
			Node nRoot = new(2)
			{
				Key = 2,
				Left = n1,
				Right = n3
			};

			Assert.Equal(1, n1.Key);
			Assert.Equal(2, nRoot.Key);
			Assert.Equal(3, n3.Key);
		}

		[Fact]
		public void NodeEntity_SetValues_ReturnNullOnChildlessNodes()
		{
			Node n1 = new(1);
			Node n3 = new(3);

			Assert.Null(n1.Left);
			Assert.Null(n3.Right);
		}

		[Fact]
		public void NodeEntity_SetValues_ThrowsWhenAccessingNodes()
		{
			Node n1 = new(1);
			Node n3 = new(3);
			Node nRoot = new(2)
			{
				Key = 2,
				Left = n1,
				Right = n3
			};

			Assert.Throws<NullReferenceException>(() => n1.Left.Key);
			Assert.Throws<NullReferenceException>(() => n3.Left.Key);
		}
	}
}
