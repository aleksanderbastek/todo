using System;
using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.Domain.Handlers.Commands.Todo
{
    public class ChangeTodoTitleCommand: ICommand<ChangeTodoTitleResult>
    {
		public string TodoId { get; set; }
		public string Title { get; set; }
	}
}
