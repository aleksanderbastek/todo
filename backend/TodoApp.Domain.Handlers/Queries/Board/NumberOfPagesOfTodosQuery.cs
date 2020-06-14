using System;
using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.Domain.Handlers.Queries.Board
{
    public class NumberOfPagesOfTodosQuery: IQuery<NumberOfPagesOfTodosResult>
    {
		public string BoardId { get; set; }
		public int NumberOfTodosPerPage { get; set; }
	}
}
