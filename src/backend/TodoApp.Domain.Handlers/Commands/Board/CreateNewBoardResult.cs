using System;

namespace TodoApp.Domain.Handlers.Commands.Board
{
    public class CreateNewBoardResult
    {
		public string BoardId { get; set; }
		public DateTime CreationDate { get; set; }
	}
}
