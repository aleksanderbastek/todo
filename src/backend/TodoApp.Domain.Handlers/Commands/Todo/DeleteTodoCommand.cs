using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.Domain.Handlers.Commands.Todo
{
    public class DeleteTodoCommand: ICommand<DeleteTodoResult>
    {
        public string TodoId { get; set; }
	}
}
