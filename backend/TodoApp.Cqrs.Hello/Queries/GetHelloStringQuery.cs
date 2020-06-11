using System;
using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.Cqrs.Hello.Queries
{
	public class GetHelloStringQuery : IQuery<GetHelloStringQueryResult>
	{
		public GetHelloStringQuery(string helloWord)
		{
			this.HelloWord = helloWord;

		}
		public string HelloWord { get; }
	}
}
