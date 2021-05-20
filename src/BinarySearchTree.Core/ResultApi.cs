using System;

namespace BinarySearchTree.Core.Entities
{
	public class ResultApi<T> where T : IConvertible
	{
		public ResultApi(bool sucess, string message)
		{
			Success = sucess;
			Message = message;
		}

		public ResultApi(bool success, string message, T result)
		{
			Success = success;
			Message = message;
			Result = result;
		}

		public bool Success { get; }
		public string Message { get; }
		public T Result { get; }

		public static ResultApi<T> Create(bool success, string message)
			=> new(success, message);

		public static ResultApi<T> Create(bool success, string message, T result)
			=> new(success, message, result);
	}
}
