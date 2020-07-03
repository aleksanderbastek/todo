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
	public class ReadableBoardRepository : IReadableBoardRepository
	{
		private TodoDbContext context;

		public ReadableBoardRepository(TodoDbContext context)
		{
			this.context = context;
		}

		public Task<bool> CheckBoardExistsAsync(string boardId)
		{
			var board = new Board
			{
				Id = boardId
			};

			return context.Boards.ContainsAsync(board);
		}

		public Task<List<Board>> GetAllBoardsAsync(int take, int skip)
		{
			return context.Boards
				.OrderBy(b => b.CreationDate)
				.Skip(skip)
				.Take(take)
				.ToListAsync();
		}

		public async Task<Board> GetBoardInfoByIdAsync(string boardId)
		{
			if (!await CheckBoardExistsAsync(boardId)) {
				throw new ArgumentException("Board with specified Id does not exist");
			}
		
			return await context.Boards.SingleAsync(b => b.Id == boardId);
		}
	}
}
