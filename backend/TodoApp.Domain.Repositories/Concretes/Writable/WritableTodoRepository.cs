using System;
using System.Threading.Tasks;
using TodoApp.Domain.Contexts;
using TodoApp.Domain.Contexts.Extensions;
using TodoApp.Domain.Models;
using TodoApp.Domain.Repositories.Abstractions.Readable;
using TodoApp.Domain.Repositories.Abstractions.Writable;

namespace TodoApp.Domain.Repositories.Concretes.Writable
{
	public class WritableTodoRepository : IWritableTodoRepository
	{
		private TodoDbContext context;
		private IReadableTodoRepository todoRepository;
		private IReadableBoardRepository boardRepository;

		public WritableTodoRepository(TodoDbContext context, IReadableTodoRepository todoRepository, IReadableBoardRepository boardRepository)
		{
			this.context = context;
			this.todoRepository = todoRepository;
			this.boardRepository = boardRepository;
		}

		public async Task<Todo> AddTodoAsync(Todo todo)
		{
			if (!await boardRepository.CheckBoardExistsAsync(todo.BoardId)) {
				throw new ArgumentException("Board with specified Id does not exist");
			}

			todo.Id = null;
			todo.CreationDate = DateTime.Now;

			context.Todos.Add(todo);
			await context.SaveChangesAsync();

			context.Detach(todo);

			return todo;
		}

		public async Task<Todo> RemoveTodoAsync(Todo todo)
		{
			if (!await todoRepository.CheckTodoExistsAsync(todo.Id)) {
				throw new ArgumentException("Todo with specified Id does not exist");
			}

			context.Todos.Remove(todo);
			await context.SaveChangesAsync();

			return todo;
		}

		public async Task<Todo> UpdateTodoAsync(Todo todo)
		{
			if (!await todoRepository.CheckTodoExistsAsync(todo.Id)) {
				throw new ArgumentException("Todo with specified Id does not exist");
			}

			context.Todos.Update(todo);
			await context.SaveChangesAsync();

			context.Detach(todo);

			return todo;
		}

		public async Task<Todo> UpdateTodoDeadlineAsync(Todo todo)
		{
			if (!await todoRepository.CheckTodoExistsAsync(todo.Id)) {
				throw new ArgumentException("Todo with specified Id does not exist");
			}

			if (todo.Deadline != null) {
				var actualTodo = await todoRepository.GetTodoAsync(todo.Id);

				if (actualTodo.CreationDate > todo.Deadline) {
					throw new ArgumentException("Todo deadline cannot be earlier than todo creation date");
				}
			}

			context.Entry(todo).Property(t => t.Deadline).IsModified = true;
			await context.SaveChangesAsync();

			context.Detach(todo);

			return todo;
		}

		public async Task<Todo> UpdateTodoDoneDateAsync(Todo todo)
		{
			if (!await todoRepository.CheckTodoExistsAsync(todo.Id)) {
				throw new ArgumentException("Todo with specified Id does not exist");
			}

			if (todo.DoneDate != null)
			{
				var actualTodo = await todoRepository.GetTodoAsync(todo.Id);

				if (actualTodo.DoneDate <= todo.CreationDate)
				{
					throw new ArgumentException("Todo done date cannot be earlier than todo creation date");
				}
			}

			context.Entry(todo).Property(t => t.DoneDate).IsModified = true;
			await context.SaveChangesAsync();

			context.Detach(todo);

			return todo;
		}

		public async Task<Todo> UpdateTodoTitleAsync(Todo todo)
		{
			if (!await todoRepository.CheckTodoExistsAsync(todo.Id)) {
				throw new ArgumentException("Todo with specified Id does not exist");
			}

			if (string.IsNullOrWhiteSpace(todo.Title)) {
				throw new ArgumentException("Cannot change todo title to null or white space");
			}

			context.Entry(todo).Property(t => t.Title).IsModified = true;
			await context.SaveChangesAsync();

			context.Detach(todo);

			return todo;
		}
	}
}
