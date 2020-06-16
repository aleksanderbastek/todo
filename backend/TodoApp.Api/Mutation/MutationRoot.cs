using System;
using System.Threading.Tasks;
using TodoApp.Cqrs.Types.Abstract;
using TodoApp.Domain.Handlers.Commands.Board;
using TodoApp.Domain.Handlers.Commands.Todo;
using TodoApp.GraphQL.Types;

namespace TodoApp.Api.Mutation
{
	public class TodoMutationRoot: MutationRoot
    {
		private readonly ICommandProcessor processor;

		public TodoMutationRoot(ICommandProcessor processor)
		{
			this.processor = processor;
		}

		public async Task<MutationResult<CreateNewBoardResult>> CreateBoard(string title, string? description) {
			var request = new CreateNewBoardCommand
			{
				Title = title,
				Description = description
			};

			try
			{
				var commandResult = await processor.Run(request);
				return MutationResult<CreateNewBoardResult>.Success(commandResult);
			} catch (Exception e) {
				return MutationResult<CreateNewBoardResult>.Error(e);
			}
		}

		public async Task<MutationResult> DeleteBoard(string id) {
			var request = new DeleteBoardCommand
			{
				BoardId = id
			};

			try
			{
				await processor.Run(request);
				return MutationResult.Success();
			} catch (Exception e) {
				return MutationResult.Error(e);
			}
		}

		public BoardMutationType Board(string id) {
			return new BoardMutationType(id, processor);
		}

		public async Task<MutationResult<AddNewTodoResult>> CreateTodo(string boardId, string title, DateTime? deadline) {
			var request = new AddNewTodoCommand
			{
				BoardId = boardId,
				Title = title,
				Deadline = deadline
			};

			try
			{
				var commandResult = await processor.Run(request);
				return MutationResult<AddNewTodoResult>.Success(commandResult);
			} catch (Exception e) {
				return MutationResult<AddNewTodoResult>.Error(e);
			}
		}

		public async Task<MutationResult> DeleteTodo(string id) {
			var request = new DeleteTodoCommand
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

		public TodoMutationType Todo(string id) {
			return new TodoMutationType(id, processor);
		}
    }
}
