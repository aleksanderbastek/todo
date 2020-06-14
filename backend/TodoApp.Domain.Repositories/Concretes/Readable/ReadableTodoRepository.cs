using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Contexts;
using TodoApp.Domain.Models;
using TodoApp.Domain.Repositories.Abstractions.Readable;

namespace TodoApp.Domain.Repositories.Concretes.Readable
{
	public class ReadableTodoRepository : IReadableTodoRepository
	{
		private TodoDbContext context;
		private IReadableBoardRepository boardRepository;

		public ReadableTodoRepository(TodoDbContext context, IReadableBoardRepository boardRepository)
		{
			this.context = context;
			this.boardRepository = boardRepository;
		}

		public Task<bool> CheckTodoExistsAsync(string todoId)
		{
			var todo = new Todo
			{
				Id = todoId
			};

			return CheckTodoExistsAsync(todo);
		}

		public Task<bool> CheckTodoExistsAsync(Todo todo)
		{
			return context.Todos.ContainsAsync(todo);
		}

		public Task<List<Todo>> GetAllTodosOfBoardAsync(Board board)
		{
			return GetAllTodosOfBoardAsync(board.Id);
		}

		public async Task<List<Todo>> GetAllTodosOfBoardAsync(string boardId)
		{
			if (!await boardRepository.CheckBoardExistsAsync(boardId)) {
				throw new ArgumentException("Board with specified Id does not exist");
			}

			return await context.Todos.Where(t => t.BoardId == boardId).ToListAsync();
		}

		public Task<int> GetNumberOfTodosOfBoardAsync(Board board)
		{
			return GetNumberOfTodosOfBoardAsync(board.Id);
		}

		public async Task<int> GetNumberOfTodosOfBoardAsync(string boardId)
		{
			if (!await boardRepository.CheckBoardExistsAsync(boardId)) {
				throw new ArgumentException("Board with specified Id does not exist");
			}

			return await context.Todos
				.Where(t => t.BoardId == boardId)
				.CountAsync();
		}

		public Task<List<Todo>> GetSubsetOfTodosOfBoardAsync(Board board, int numberOfTodos, int numberOfTodosToSkip)
		{
			return GetSubsetOfTodosOfBoardAsync(board.Id, numberOfTodos, numberOfTodosToSkip);
		}

		public async Task<List<Todo>> GetSubsetOfTodosOfBoardAsync(string boardId, int numberOfTodos, int numberOfTodosToSkip)
		{
			if (!await boardRepository.CheckBoardExistsAsync(boardId)) {
				throw new ArgumentException("Board with specified Id does not exist");
			}

			return await context.Todos
				.Where(t => t.BoardId == boardId)
				.OrderBy(t => t.CreationDate)
				.Skip(numberOfTodosToSkip)
				.Take(numberOfTodos)
				.ToListAsync();
		}
	}
}
