using System;
using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.Domain.Handlers.Queries.Board
{
    public class AllBoardsQuery: IQuery<AllBoardsResult>
    {
		public int Take { get; set; }
		public int Skip { get; set; }
	}
}
