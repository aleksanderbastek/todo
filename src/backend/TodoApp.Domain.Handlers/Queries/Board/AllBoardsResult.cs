using System.Collections.Generic;

namespace TodoApp.Domain.Handlers.Queries.Board
{
	public class AllBoardsResult
    {
		public int Take { get; set; }
		public int Skip { get; set; }
		public List<Models.Board> Result { get; set; }
	}
}
