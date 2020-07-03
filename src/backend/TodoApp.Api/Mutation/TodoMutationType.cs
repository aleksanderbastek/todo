using System;
using System.Threading.Tasks;
using TodoApp.Cqrs.Types.Abstract;
using TodoApp.Domain.Handlers.Commands.Todo;

namespace TodoApp.Api.Mutation
{
    public class TodoMutationType
    {
		private readonly ICommandProcessor processor;
		private readonly string id;

		public TodoMutationType(string todoId, ICommandProcessor processor)
		{
			this.id = todoId;
			this.processor = processor;
		}

		public async Task<MutationResult> UpdateTitle(string title) {
			var request = new ChangeTodoTitleCommand
			{
				TodoId = id,
				Title = title
			};

			try {
				await processor.Run(request);
				return MutationResult.Success();
			} catch (Exception e) {
				return MutationResult.Error(e);
			}
		}

		public async Task<MutationResult<MarkTodoAsDoneResult>> MarkTodoAsDone(DateTime? doneDate) {
			var request = new MarkTodoAsDoneCommand
			{
				TodoId = id,
				DoneDate = doneDate ?? DateTime.Now
			};

			try {
				var commandResult = await processor.Run(request);
				return MutationResult<MarkTodoAsDoneResult>.Success(commandResult);
			} catch (Exception e) {
				return MutationResult<MarkTodoAsDoneResult>.Error(e);
			}
		}

		public async Task<MutationResult> MarkTodoAsUndone(DateTime? doneDate) {
			var request = new MarkTodoAsUndoneCommand
			{
				TodoId = id
			};

			try {
				await processor.Run(request);
				return MutationResult.Success();
			} catch (Exception e) {
				return MutationResult.Error(e);
			}
		}

		public async Task<MutationResult> UpdateDeadline(DateTime? deadline) {
			var request = new ChangeTodoDeadlineCommand
			{
				TodoId = id,
				NewDeadline = deadline
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
