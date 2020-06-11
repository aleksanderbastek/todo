using System;

namespace TodoApp.Cqrs.Hello.Queries
{
	public class GetHelloStringQueryResult
	{
		public GetHelloStringQueryResult(string helloString, string helloWordUsedInHelloString)
		{
			HelloString = helloString;
			HelloWordUsedInHelloString = helloWordUsedInHelloString;
		}

		public string HelloString { get; }
		public string HelloWordUsedInHelloString { get; }
	}
}
