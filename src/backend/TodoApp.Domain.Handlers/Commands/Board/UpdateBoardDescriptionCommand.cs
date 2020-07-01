using System;
using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.Domain.Handlers.Commands.Board
{
    public class UpdateBoardDescriptionCommand: ICommand<UpdateBoardDescriptionResult>
    {
		public string BoardId { get; set; }
		public string Description { get; set; }
	}
}
