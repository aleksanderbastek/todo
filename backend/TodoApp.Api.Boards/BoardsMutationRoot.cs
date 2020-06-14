using System;
using TodoApp.Api.Boards.Mutations;
using TodoApp.GraphQL.Types;

namespace TodoApp.Api.Boards
{
	public class BoardsMutationRoot : MutationRoot
	{
		public BoardsMutationRoot(BoardMutation board)
		{
			this.Board = board;
		}
		
		public BoardMutation Board { get; set; }
	}
}
