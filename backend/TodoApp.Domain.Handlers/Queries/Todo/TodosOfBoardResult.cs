using System;
using System.Collections.Generic;

namespace TodoApp.Domain.Handlers.Queries.Todo
{
    public class TodosOfBoardResult
    {
		public string BoardId { get; set; }
		public int NumberOfRequestedTodos { get; set; }
		public int NumberOfSkippedTodos { get; set; }
		public List<Models.Todo> Result { get; set; }
	}
}
