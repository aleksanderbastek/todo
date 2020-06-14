using System;
using System.Threading.Tasks;
using TodoApp.Cqrs.Types.Abstract;
using TodoApp.Domain.Handlers.Commands.Board;
using TodoApp.GraphQL.Types;

namespace TodoApp.Api.Boards.Mutations
{
	public class BoardMutation : Mutation
	{
		public BoardMutation(ICommandProcessor processor) : base(processor)
		{
		}

		public async Task<CreateNewBoardResult> CreateNewBoard(string title, string description) {
			var request = new CreateNewBoardCommand
			{
				Title = title,
				Description = description
			};

			return await processor.Run(request);
		}

		public async Task<DeleteBoardResult> DeleteBoard(string boardId) {
			var request = new DeleteBoardCommand
			{
				BoardId = boardId
			};

			return await processor.Run(request);
		}

		public async Task<UpdateBoardInfoResult> UpdateBoardInfo(string boardId, string title, string description) {
			var request = new UpdateBoardInfoCommand
			{
				BoardId = boardId,
				Title = title,
				Description = description
			};

			return await processor.Run(request);
		}
	}
}
