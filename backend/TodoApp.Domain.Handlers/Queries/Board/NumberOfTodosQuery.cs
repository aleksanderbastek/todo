using System;
using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.Domain.Handlers.Queries.Board
{
    public class NumberOfTodosQuery: IQuery<NumberOfTodosResult>
    {
		public enum Filter {
			ALL,
			DONE,
			UNDONE
		}

		public string BoardId { get; set; }
		public Filter TodoFilter { get; set; } = Filter.ALL;
	}
}
