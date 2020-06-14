using System;

namespace TodoApp.Domain.Handlers.Commands.Board
{
    public class UpdateBoardInfoResult
    {
		public string BoardId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
	}
}
