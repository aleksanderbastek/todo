using System;
using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.Domain.Handlers.Commands.Todo
{
    public class MarkTodoAsUndoneCommand: ICommand<MarkTodoAsUndoneResult>
    {
		public string TodoId { get; set; }
    }
}
