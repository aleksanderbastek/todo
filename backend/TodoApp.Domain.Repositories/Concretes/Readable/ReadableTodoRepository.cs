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

			return context.Todos.ContainsAsync(todo);
		}

		public async Task<Todo> GetTodoAsync(string todoId)
		{
			if (!await CheckTodoExistsAsync(todoId)) {
				throw new ArgumentException("Todo with specified Id does not exist");
			}

			return await context.Todos.SingleAsync(t => t.Id == todoId);
		}

		public async Task<List<Todo>> GetAllTodosOfBoardAsync(string boardId)
		{
			if (!await boardRepository.CheckBoardExistsAsync(boardId)) {
				throw new ArgumentException("Board with specified Id does not exist");
			}

			return await context.Todos.Where(t => t.BoardId == boardId).ToListAsync();
		}

		public async Task<List<Todo>> GetDoneTodosOfBoardAsync(string boardId, int numberOfTodos, int numberOfTodosToSkip)
		{
			if (!await boardRepository.CheckBoardExistsAsync(boardId)) {
				throw new ArgumentException("Board with specified Id does not exist");
			}

			return await context.Todos
				.Where(t => t.BoardId == boardId && t.DoneDate != null)
				.Skip(numberOfTodosToSkip)
				.Take(numberOfTodos)
				.ToListAsync();
		}

		public async Task<List<Todo>> GetUndoneTodosOfBoardAsync(string boardId, int numberOfTodos, int numberOfTodosToSkip)
		{
			if (!await boardRepository.CheckBoardExistsAsync(boardId)) {
				throw new ArgumentException("Board with specified Id does not exist");
			}

			return await context.Todos
				.Where(t => t.BoardId == boardId && t.DoneDate == null)
				.Skip(numberOfTodosToSkip)
				.Take(numberOfTodos)
				.ToListAsync();
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

		public async Task<int> GetNumberOfDoneTodosOfBoardAsync(string boardId)
		{
			if (!await boardRepository.CheckBoardExistsAsync(boardId)) {
				throw new ArgumentException("Board with specified Id does not exist");
			}

			return await context.Todos
				.Where(t => t.BoardId == boardId && t.DoneDate != null)
				.CountAsync();
		}

		public async Task<int> GetNumberOfUndoneTodosOfBoardAsync(string boardId)
		{
			if (!await boardRepository.CheckBoardExistsAsync(boardId)) {
				throw new ArgumentException("Board with specified Id does not exist");
			}

			return await context.Todos
				.Where(t => t.BoardId == boardId && t.DoneDate == null)
				.CountAsync();
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
