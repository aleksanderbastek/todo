using System;
using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.Domain.Handlers.Queries.Todo
{
    public class TodoInfoQuery: IQuery<TodoInfoResult>
    {
		public string TodoId { get; set; }
	}
}
