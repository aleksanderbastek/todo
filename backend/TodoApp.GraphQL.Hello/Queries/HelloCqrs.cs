using System.Threading.Tasks;
using TodoApp.Cqrs.Hello.Queries;
using TodoApp.Cqrs.Types.Abstract;
using TodoApp.GraphQL.Types;

namespace TodoApp.GraphQL.Hello.Queries
{
	public class HelloCqrs : Query
	{
		public HelloCqrs(IQueryProcessor processor) : base(processor)
		{
		}

		public async Task<string> SayHelloCqrs(string customHelloWord)
		{
			var result = await processor.Query(new GetHelloStringQuery(customHelloWord));
			return result.HelloString;
		}
	}
}
