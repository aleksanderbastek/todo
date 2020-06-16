using System;
using System.Collections.Generic;
using System.Linq;
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

		/// <summary>
		/// NOTE: Available only in DEVELOPMENT environment for development purposes.
		/// It will not be exposed in PRODUCTION environment to our clients.
		/// You can build development helper showing you names and boards IDs
		/// using this query.
		/// </summary>
		public async Task<List<BoardType>> Boards(int take, int? skip) {
			var request = new AllBoardsQuery
			{
				Take = take,
				Skip = skip ?? 0
			};

			var queryResult = await processor.Query(request);

			var result = from board in queryResult.Result select new BoardType(board, processor);

			return result.ToList();
		}
    }
}
