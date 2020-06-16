using System;
using System.Threading.Tasks;
using TodoApp.Cqrs.Types.Abstract;
using TodoApp.Domain.Handlers.Queries.Board;
using TodoApp.GraphQL.Types;

namespace TodoApp.Api.Query
{
    public class TodoQueryRoot: QueryRoot
    {
		private readonly IQueryProcessor processor;

		public TodoQueryRoot(IQueryProcessor processor)
		{
			this.processor = processor;
		}

		public async Task<BoardType> Board(string id) {
			var request = new BoardInfoQuery
			{
				BoardId = id
			};

			var board = await processor.Query(request);

			return new BoardType(board, processor);
		}
    }
}
