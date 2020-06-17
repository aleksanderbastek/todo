using System.Runtime.CompilerServices;
using System;

namespace TodoApp.Api.Mutation
{
    public class MutationResult
    {
		protected MutationResult() { }

		public static MutationResult Success() {
			return new MutationResult
			{
				IsSuccessfull = true,
				ErrorReason = null
			};
		}

		public static MutationResult Error(Exception reason) {
			return new MutationResult
			{
				IsSuccessfull = false,
				ErrorReason = reason.Message
			};
		}

		public bool IsSuccessfull { get; protected set; }
		public string? ErrorReason { get; protected set; }
	}

	public class MutationResult<TResult>: MutationResult
		where TResult: class
	{
		public static MutationResult<TResult> Success(TResult result)
		{
			return new MutationResult<TResult>
			{
				IsSuccessfull = true,
				Result = result,
				ErrorReason = null
			};
		}
		
		new public static MutationResult<TResult> Error(Exception reason)
		{
			return new MutationResult<TResult>
			{
				IsSuccessfull = false,
				ErrorReason = reason.Message
			};
		}

		public TResult? Result { get; protected set; }
	}
}
