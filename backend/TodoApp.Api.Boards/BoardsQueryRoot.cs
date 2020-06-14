using System;
using TodoApp.Api.Boards.Queries;
using TodoApp.GraphQL.Types;

namespace TodoApp.Api.Boards
{
	public class BoardsQueryRoot : QueryRoot
	{
		public BoardsQueryRoot(BoardQuery board)
		{
			this.Board = board;
		}
		
		public BoardQuery Board { get; set; }
	}
}
