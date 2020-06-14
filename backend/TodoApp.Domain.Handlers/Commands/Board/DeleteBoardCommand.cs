using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.Domain.Handlers.Commands.Board
{
    public class DeleteBoardCommand: ICommand<DeleteBoardResult>
    {
		public string BoardId { get; set; }
	}
}
