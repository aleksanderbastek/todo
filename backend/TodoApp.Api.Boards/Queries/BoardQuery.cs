using TodoApp.GraphQL.Types;
using System.Threading.Tasks;
using TodoApp.Domain.Handlers.Queries.Board;
using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.Api.Boards.Queries
{
	public class BoardQuery : Query
	{
		public BoardQuery(IQueryProcessor processor) : base(processor)
		{
		}

		public async Task<AllBoardsResult> AllBoards() {
			var request = new AllBoardsQuery();
			return await processor.Query(request);
		}

		public async Task<BoardInfoResult> BoardInfo(string boardId) {
			var request = new BoardInfoQuery
			{
				BoardId = boardId
			};

			return await processor.Query(request);
		}

		public async Task<NumberOfTodosResult> NumberOfTodos(string boardId) {
			var request = new NumberOfTodosQuery
			{
				BoardId = boardId
			};

			return await processor.Query(request);
		}

		public async Task<NumberOfPagesOfTodosResult> NumberOfPagesOfTodos(string boardId, int numberOfTodosPerPage) {
			var request = new NumberOfPagesOfTodosQuery
			{
				BoardId = boardId,
				NumberOfTodosPerPage = numberOfTodosPerPage
			};

			return await processor.Query(request);
		}
	}
}
