using System;
using System.Threading.Tasks;
using TodoApp.Cqrs.Types.Abstract;
using TodoApp.Domain.Handlers.Commands.Board;

namespace TodoApp.Api.Mutation
{
    public class BoardMutationType
    {
		private readonly string id;
		private readonly ICommandProcessor processor;

		public BoardMutationType(string id, ICommandProcessor processor)
		{
			this.id = id;
			this.processor = processor;
		}

		public async Task<MutationResult> UpdateBoardTitle(string title) {
			var request = new UpdateBoardTitleCommand
			{
				BoardId = id,
				Title = title
			};

			try {
				await processor.Run(request);
				return MutationResult.Success();
			} catch (Exception e) {
				return MutationResult.Error(e);
			}
		}

		public async Task<MutationResult> UpdateBoardDescription(string? description) {
			var request = new UpdateBoardDescriptionCommand
			{
				BoardId = id,
				Description = description
			};

			try {
				await processor.Run(request);
				return MutationResult.Success();
			} catch (Exception e) {
				return MutationResult.Error(e);
			}
		}
    }
}
