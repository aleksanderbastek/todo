using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.Domain.Handlers.Commands.Board
{
    public class CreateNewBoardCommand: ICommand<CreateNewBoardResult>
    {
        public string Title { get; set; }
		public string Description { get; set; }
	}
}
