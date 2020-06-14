using System;

namespace TodoApp.Domain.Handlers.Commands.Todo
{
    public class MarkTodoAsDoneResult
    {
		public string TodoId { get; set; }
		public DateTime? DoneDate { get; set; }
    }
}
