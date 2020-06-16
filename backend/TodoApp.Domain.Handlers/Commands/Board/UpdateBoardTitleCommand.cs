using System;
using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.Domain.Handlers.Commands.Board
{
    public class UpdateBoardTitleCommand: ICommand<UpdateBoardTitleResult>
    {
		public string BoardId { get; set; }
		public string Title { get; set; }
	}
}
