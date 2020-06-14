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
		IQueryHandler<NumberOfPagesOfTodosQuery, NumberOfPagesOfTodosResult>
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

			var result = await boardRepository.GetBoardInfoByIdAsync(request.BoardId);

			return new BoardInfoResult
			{
				Id = result.Id,
				Title = result.Title,
				Description = result.Description,
				CreationDate = result.CreationDate ?? DateTime.Now
			};
		}

		public async Task<NumberOfTodosResult> Handle(NumberOfTodosQuery request, CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(request.BoardId)) {
				throw new ArgumentException("BoardId cannot be null or white space");
			}

			var result = await todoRepository.GetNumberOfTodosOfBoardAsync(request.BoardId);

			return new NumberOfTodosResult
			{
				BoardId = request.BoardId,
				NumberOfTodos = result
			};
		}

		public async Task<NumberOfPagesOfTodosResult> Handle(NumberOfPagesOfTodosQuery request, CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(request.BoardId)) {
				throw new ArgumentException("BoardId cannot be null or white space");
			}

			var numberOfTodos = await todoRepository.GetNumberOfTodosOfBoardAsync(request.BoardId);
			var result = (numberOfTodos % request.NumberOfTodosPerPage) > 0
				? (numberOfTodos / request.NumberOfTodosPerPage) + 1
				: numberOfTodos / request.NumberOfTodosPerPage;
			
			return new NumberOfPagesOfTodosResult
			{
				BoardId = request.BoardId,
				NumberOfTodosPerPage = request.NumberOfTodosPerPage,
				NumberOfPages = result
			};
		}
	}
}
