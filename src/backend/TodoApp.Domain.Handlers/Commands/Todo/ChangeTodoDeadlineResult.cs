using System;

namespace TodoApp.Domain.Handlers.Commands.Todo
{
    public class ChangeTodoDeadlineResult
    {
		public string TodoId { get; set; }
		public DateTime? NewDeadline { get; set; }
	}
}
