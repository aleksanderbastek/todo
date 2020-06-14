using System;
using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.Domain.Handlers.Commands.Todo
{
    public class MarkTodoAsDoneCommand: ICommand<MarkTodoAsDoneResult>
    {
		public string TodoId { get; set; }
		public DateTime? DoneDate { get; set; }
	}
}
