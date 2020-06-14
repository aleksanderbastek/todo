using System;
using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.Domain.Handlers.Commands.Board
{
    public class UpdateBoardInfoCommand: ICommand<UpdateBoardInfoResult>
    {
		public string BoardId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
	}
}
