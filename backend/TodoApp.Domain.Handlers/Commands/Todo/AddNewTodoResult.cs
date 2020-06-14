using System;

namespace TodoApp.Domain.Handlers.Commands.Todo
{
    public class AddNewTodoResult
    {
		public string TodoId { get; set; }
		public string BoardId { get; set; }
		public DateTime CreationDate { get; set; }
	}
}
