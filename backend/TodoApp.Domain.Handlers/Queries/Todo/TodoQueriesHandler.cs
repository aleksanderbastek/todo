using System;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Cqrs.Types.Abstract;
using TodoApp.Domain.Repositories.Abstractions.Readable;

namespace TodoApp.Domain.Handlers.Queries.Todo
{
	public class TodoQueriesHandler :
		IQueryHandler<TodosOfBoardQuery, TodosOfBoardResult>
	{
		private IReadableTodoRepository todoRepository;

		public TodoQueriesHandler(IReadableTodoRepository todoRepository)
		{
			this.todoRepository = todoRepository;
		}

		public async Task<TodosOfBoardResult> Handle(TodosOfBoardQuery request, CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(request.BoardId)) {
				throw new ArgumentException("BoardId cannot be null or white space");
			}

			if (request.NumberOfRequestedTodos < 1) {
				throw new ArgumentException("NumberOfRequestedTodos cannot be less than one");
			}

			var result = await todoRepository.GetSubsetOfTodosOfBoardAsync(
				request.BoardId,
				request.NumberOfRequestedTodos,
				request.NumberOfSkippedTodos
			);

			return new TodosOfBoardResult
			{
				BoardId = request.BoardId,
				NumberOfRequestedTodos = request.NumberOfRequestedTodos,
				NumberOfSkippedTodos = request.NumberOfSkippedTodos,
				Result = result
			};
		}
	}
}
