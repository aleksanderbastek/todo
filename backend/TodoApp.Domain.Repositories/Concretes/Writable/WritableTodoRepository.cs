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
	}
}
