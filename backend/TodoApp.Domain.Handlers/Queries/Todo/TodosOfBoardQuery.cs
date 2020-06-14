using System;
using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.Domain.Handlers.Queries.Todo
{
    public class TodosOfBoardQuery: IQuery<TodosOfBoardResult>
    {
		public string BoardId { get; set; }
		public int NumberOfRequestedTodos { get; set; }
		public int NumberOfSkippedTodos { get; set; }
	}
}
