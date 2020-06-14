using System.Threading.Tasks;
using System;
using TodoApp.Cqrs.Types.Abstract;
using TodoApp.GraphQL.Types;
using TodoApp.Domain.Handlers.Commands.Todo;

namespace TodoApp.Api.Todos.Mutations
{
	public class TodosMutation : Mutation
	{
		public TodosMutation(ICommandProcessor processor) : base(processor)
		{
		}

		public async Task<AddNewTodoResult> AddNewTodo(string boardId, string title, DateTime? deadline) {
			var request = new AddNewTodoCommand
			{
				BoardId = boardId,
				Title = title,
				Deadline = deadline
			};

			return await processor.Run(request);
		}

		public async Task<DeleteTodoResult> DeleteTodo(string todoId) {
			var request = new DeleteTodoCommand
			{
				TodoId = todoId
			};

			return await processor.Run(request);
		}

		public async Task<ChangeTodoTitleResult> ChangeTodoTitle(string todoId, string newTitle) {
			var request = new ChangeTodoTitleCommand
			{
				TodoId = todoId,
				Title = newTitle
			};

			return await processor.Run(request);
		}

		public async Task<ChangeTodoDeadlineResult> ChangeTodoDeadline(string todoId, DateTime? newDeadline) {
			var request = new ChangeTodoDeadlineCommand
			{
				TodoId = todoId,
				NewDeadline = newDeadline
			};

			return await processor.Run(request);
		}

		public async Task<MarkTodoAsDoneResult> MarkTodoAsDone(string todoId, DateTime? doneDate) {
			var request = new MarkTodoAsDoneCommand
			{
				TodoId = todoId,
				DoneDate = doneDate
			};

			return await processor.Run(request);
		}
		
		public async Task<MarkTodoAsUndoneResult> MarkTodoAsUndone(string todoId) {
			var request = new MarkTodoAsUndoneCommand
			{
				TodoId = todoId
			};

			return await processor.Run(request);
		}
	}
}
