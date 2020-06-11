using System;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.Cqrs.Hello.Queries
{
	public class GetHelloStringQueryHandler : IQueryHandler<GetHelloStringQuery, GetHelloStringQueryResult>
	{
		public async Task<GetHelloStringQueryResult> Handle(GetHelloStringQuery request, CancellationToken cancellationToken)
		{
			return new GetHelloStringQueryResult(
				$"{request.HelloWord} World from ExampleHelloQueryHandler!",
				request.HelloWord
			);
		}
	}
}
