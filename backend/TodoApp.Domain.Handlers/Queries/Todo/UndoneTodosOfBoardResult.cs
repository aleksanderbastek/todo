using System;
using System.Collections.Generic;

namespace TodoApp.Domain.Handlers.Queries.Todo
{
    public class UndoneTodosOfBoardResult
    {
		public string BoardId { get; set; }
		public int Take { get; set; }
		public int Skip { get; set; }
		public List<Models.Todo> Result { get; set; }
    }
}
