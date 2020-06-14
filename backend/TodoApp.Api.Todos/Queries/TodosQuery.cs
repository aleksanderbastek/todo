using System.Threading.Tasks;
using System;
using TodoApp.Cqrs.Types.Abstract;
using TodoApp.GraphQL.Types;
using TodoApp.Domain.Handlers.Queries.Todo;

namespace TodoApp.Api.Todos.Queries
{
	public class TodosQuery : Query
	{
		public TodosQuery(IQueryProcessor processor) : base(processor)
		{
		}

		public async Task<TodosOfBoardResult> TodosOfBoard(string boardId, int amount, int skip) {
			var request = new TodosOfBoardQuery
			{
				BoardId = boardId,
				NumberOfRequestedTodos = amount,
				NumberOfSkippedTodos = skip
			};

			return await processor.Query(request);
		}
	}
}
