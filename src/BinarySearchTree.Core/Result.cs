namespace BinarySearchTree.Core.Entities
{
	public class Result<T> where T : class
	{
		public Result(bool success, string message, T resultObject)
		{
			Success = success;
			Message = message;
			ResultObject = resultObject;
		}

		public bool Success { get; }
		public string Message { get; }
		public T ResultObject { get; }

		public static Result<T> Create(bool success, string message)
			=> new(success, message, null);

		public static Result<T> Create(bool success, T resultObject)
			=> new(success, null, resultObject);

		public static Result<T> Create(bool success, string message, T resultObject)
			=> new(success, message, resultObject);
	}
}
