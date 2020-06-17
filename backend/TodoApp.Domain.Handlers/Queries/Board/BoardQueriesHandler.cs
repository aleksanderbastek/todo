using System;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Cqrs.Types.Abstract;
using TodoApp.Domain.Repositories.Abstractions.Readable;

namespace TodoApp.Domain.Handlers.Queries.Board
{
	public class BoardQueriesHandler :
		IQueryHandler<BoardInfoQuery, BoardInfoResult>,
		IQueryHandler<NumberOfTodosQuery, NumberOfTodosResult>,
		IQueryHandler<AllBoardsQuery, AllBoardsResult>
	{
		private IReadableBoardRepository boardRepository;
		private IReadableTodoRepository todoRepository;

		public BoardQueriesHandler(IReadableBoardRepository boardRepository, IReadableTodoRepository todoRepository)
		{
			this.boardRepository = boardRepository;
			this.todoRepository = todoRepository;
		}

		public async Task<BoardInfoResult> Handle(BoardInfoQuery request, CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(request.BoardId)) {
				throw new ArgumentException("BoardId cannot be null or white space");
			}

			if (!await boardRepository.CheckBoardExistsAsync(request.BoardId)) {
				return new BoardInfoResult
				{
					Result = null
				};
			}

			var result = await boardRepository.GetBoardInfoByIdAsync(request.BoardId);

			return new BoardInfoResult
			{
				Result = result
			};
		}

		public async Task<NumberOfTodosResult> Handle(NumberOfTodosQuery request, CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(request.BoardId)) {
				throw new ArgumentException("BoardId cannot be null or white space");
			}

			int result = 0;

			switch (request.TodoFilter) {
				case NumberOfTodosQuery.Filter.DONE:
					result = await todoRepository.GetNumberOfDoneTodosOfBoardAsync(request.BoardId);
					break;
				case NumberOfTodosQuery.Filter.UNDONE:
					result = await todoRepository.GetNumberOfUndoneTodosOfBoardAsync(request.BoardId);
					break;
				default:
					result = await todoRepository.GetNumberOfTodosOfBoardAsync(request.BoardId);
					break;
			}
			
			return new NumberOfTodosResult
			{
				BoardId = request.BoardId,
				TodoFilter = request.TodoFilter,
				NumberOfTodos = result
			};
		}

		public async Task<AllBoardsResult> Handle(AllBoardsQuery request, CancellationToken cancellationToken)
		{
			if (request.Take < 1) {
				throw new ArgumentException("Cannot take less than one board");
			}

			var result = await boardRepository.GetAllBoardsAsync(request.Take, request.Skip);

			return new AllBoardsResult
			{
				Result = result,
				Take = request.Take,
				Skip = request.Skip
			};
		}
	}
}
