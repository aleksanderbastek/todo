using System;
using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.Domain.Handlers.Commands.Todo
{
	public class AddNewTodoCommand : ICommand<AddNewTodoResult>
	{
		public string BoardId { get; set; }
		public string Title { get; set; }
		public DateTime? Deadline { get; set; }
	}
}
