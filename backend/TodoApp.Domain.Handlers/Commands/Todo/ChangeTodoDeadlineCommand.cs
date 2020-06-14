using System;
using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.Domain.Handlers.Commands.Todo
{
    public class ChangeTodoDeadlineCommand: ICommand<ChangeTodoDeadlineResult>
    {
        public string TodoId { get; set; }
		public DateTime? NewDeadline { get; set; }
	}
}
