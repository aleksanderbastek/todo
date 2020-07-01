using System;
using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.Domain.Handlers.Queries.Todo
{
    public class UndoneTodosOfBoardQuery: IQuery<UndoneTodosOfBoardResult>
    {
		public string BoardId { get; set; }
		public int Take { get; set; }
		public int Skip { get; set; }
    }
}
