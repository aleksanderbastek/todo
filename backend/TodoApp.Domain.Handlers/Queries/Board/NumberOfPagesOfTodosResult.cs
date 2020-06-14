using System;

namespace TodoApp.Domain.Handlers.Queries.Board
{
    public class NumberOfPagesOfTodosResult
    {
		public string BoardId { get; set; }
		public int NumberOfTodosPerPage { get; set; }
		public int NumberOfPages { get; set; }
	}
}
