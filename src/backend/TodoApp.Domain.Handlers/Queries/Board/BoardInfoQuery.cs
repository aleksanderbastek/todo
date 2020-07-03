using System;
using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.Domain.Handlers.Queries.Board
{
    public class BoardInfoQuery: IQuery<BoardInfoResult>
    {
		public string BoardId { get; set; }
	}
}
