using System;
using System.Threading.Tasks;
using TodoApp.Domain.Contexts;
using TodoApp.Domain.Contexts.Extensions;
using TodoApp.Domain.Models;
using TodoApp.Domain.Repositories.Abstractions.Readable;
using TodoApp.Domain.Repositories.Abstractions.Writable;

namespace TodoApp.Domain.Repositories.Concretes.Writable
{
	public class WritableBoardRepository : IWritableBoardRepository
	{
		private TodoDbContext context;
		private IReadableBoardRepository boardRepository;

		public WritableBoardRepository(TodoDbContext context, IReadableBoardRepository boardRepository)
		{
			this.context = context;
			this.boardRepository = boardRepository;
		}

		public async Task<Board> AddBoardAsync(Board board)
		{
			board.Id = null;
			board.CreationDate = DateTime.Now;

			this.context.Boards.Add(board);
			await this.context.SaveChangesAsync();

			context.Detach(board);

			return board;
		}

		public async Task<Board> DeleteBoardAsync(Board board)
		{
			if (!await boardRepository.CheckBoardExistsAsync(board.Id)) {
				throw new ArgumentException("Board with specified Id does not exist");
			}

			this.context.Boards.Remove(board);
			await this.context.SaveChangesAsync();

			return board;
		}

		public async Task<Board> UpdateBoardAsync(Board board)
		{
			if (!await boardRepository.CheckBoardExistsAsync(board.Id)) {
				throw new ArgumentException("Board with specified Id does not exist");
			}

			if (board.CreationDate != null) {
				throw new ArgumentException("Cannot change board CreationDate");
			}

			context.Update(board);
			await context.SaveChangesAsync();

			context.Detach(board);

			return board;
		}

		public async Task<Board> UpdateBoardTitleAsync(Board board)
		{
			if (!await boardRepository.CheckBoardExistsAsync(board.Id)) {
				throw new ArgumentException("Board with specified Id does not exist");
			}

			if (board.CreationDate != null) {
				throw new ArgumentException("Cannot change board CreationDate");
			}

			context.Entry(board).Property(b => b.Title).IsModified = true;
			await context.SaveChangesAsync();

			context.Detach(board);

			return board;
		}

		public async Task<Board> UpdateBoardDescriptionAsync(Board board)
		{
			if (!await boardRepository.CheckBoardExistsAsync(board.Id)) {
				throw new ArgumentException("Board with specified Id does not exist");
			}

			if (board.CreationDate != null) {
				throw new ArgumentException("Cannot change board CreationDate");
			}

			context.Entry(board).Property(b => b.Description).IsModified = true;
			await context.SaveChangesAsync();

			context.Detach(board);

			return board;
		}
	}
}
