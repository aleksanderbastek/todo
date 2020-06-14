using System;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Cqrs.Types.Abstract;
using TodoApp.Domain.Repositories.Abstractions.Writable;

namespace TodoApp.Domain.Handlers.Commands.Todo
{
	public class TodoCommandsHandler :
		ICommandHandler<AddNewTodoCommand, AddNewTodoResult>,
		ICommandHandler<DeleteTodoCommand, DeleteTodoResult>,
		ICommandHandler<ChangeTodoTitleCommand, ChangeTodoTitleResult>,
		ICommandHandler<ChangeTodoDeadlineCommand, ChangeTodoDeadlineResult>,
		ICommandHandler<MarkTodoAsDoneCommand, MarkTodoAsDoneResult>,
		ICommandHandler<MarkTodoAsUndoneCommand, MarkTodoAsUndoneResult>
	{
		private IWritableTodoRepository todoRepository;

		public TodoCommandsHandler(IWritableTodoRepository todoRepository)
		{
			this.todoRepository = todoRepository;
		}

		public async Task<AddNewTodoResult> Handle(AddNewTodoCommand request, CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(request.BoardId)) {
				throw new ArgumentException("Cannot add new todo when BoardId is null or empty");
			}

			if (string.IsNullOrEmpty(request.Title)) {
				throw new ArgumentException("Cannot add new todo when Title is null or empty");
			}

			var todo = new Models.Todo
			{
				BoardId = request.BoardId,
				Title = request.Title,
				Deadline = request.Deadline
			};

			var result = await todoRepository.AddTodoAsync(todo);

			return new AddNewTodoResult
			{
				TodoId = result.Id,
				BoardId = result.BoardId,
				CreationDate = result.CreationDate
			};
		}

		public async Task<DeleteTodoResult> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(request.TodoId)) {
				throw new ArgumentException("Cannot delete todo when TodoId is null or white space");
			}

			var todo = new Models.Todo
			{
				Id = request.TodoId
			};

			var result = await todoRepository.RemoveTodoAsync(todo);

			return new DeleteTodoResult
			{
				TodoId = result.Id
			};
		}

		public async Task<ChangeTodoTitleResult> Handle(ChangeTodoTitleCommand request, CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(request.TodoId)) {
				throw new ArgumentException("Cannot change todo Title when TodoId is null or empty");
			}

			if (string.IsNullOrWhiteSpace(request.TodoId)) {
				throw new ArgumentException("Cannot change todo Title to null or empty space");
			}

			var todo = new Models.Todo
			{
				Id = request.TodoId,
				Title = request.Title
			};

			var result = await todoRepository.UpdateTodoAsync(todo);

			return new ChangeTodoTitleResult
			{
				TodoId = result.Id,
				Title = result.Title
			};
		}

		public async Task<ChangeTodoDeadlineResult> Handle(ChangeTodoDeadlineCommand request, CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(request.TodoId)) {
				throw new ArgumentException("Cannot change todo Deadline when TodoId is null or white space");
			}

			var todo = new Models.Todo
			{
				Id = request.TodoId,
				Deadline = request.NewDeadline
			};

			var result = await todoRepository.UpdateTodoAsync(todo);

			return new ChangeTodoDeadlineResult
			{
				TodoId = result.Id,
				NewDeadline = result.Deadline
			};
		}

		public async Task<MarkTodoAsDoneResult> Handle(MarkTodoAsDoneCommand request, CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(request.TodoId)) {
				throw new ArgumentException("Cannot mark todo as done when TodoId is null or white space");
			}

			if (request.DoneDate == null) {
				request.DoneDate = DateTime.Now;
			}

			var todo = new Models.Todo
			{
				Id = request.TodoId,
				DoneDate = request.DoneDate
			};

			var result = await todoRepository.UpdateTodoAsync(todo);

			return new MarkTodoAsDoneResult
			{
				TodoId = result.Id,
				DoneDate = result.DoneDate
			};
		}

		public async Task<MarkTodoAsUndoneResult> Handle(MarkTodoAsUndoneCommand request, CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(request.TodoId)) {
				throw new ArgumentException("Cannot mark todo as undone when TodoId is null or white space");
			}

			var todo = new Models.Todo
			{
				Id = request.TodoId,
				DoneDate = null
			};

			var result = await todoRepository.UpdateTodoAsync(todo);

			return new MarkTodoAsUndoneResult
			{
				TodoId = result.Id
			};
		}
	}
}
