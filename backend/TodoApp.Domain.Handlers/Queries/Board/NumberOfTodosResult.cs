using System;

namespace TodoApp.Domain.Handlers.Queries.Board
{
    public class NumberOfTodosResult
    {
		public string BoardId { get; set; }
		public int NumberOfTodos { get; set; }
	}
}
