using System;

namespace TodoApp.Domain.Handlers.Commands.Todo
{
    public class ChangeTodoTitleResult
    {
		public string TodoId { get; set; }
		public string Title { get; set; }
    }
}
