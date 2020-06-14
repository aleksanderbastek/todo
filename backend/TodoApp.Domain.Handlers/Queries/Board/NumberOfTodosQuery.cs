using System;
using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.Domain.Handlers.Queries.Board
{
    public class NumberOfTodosQuery: IQuery<NumberOfTodosResult>
    {
		public string BoardId { get; set; }
	}
}
