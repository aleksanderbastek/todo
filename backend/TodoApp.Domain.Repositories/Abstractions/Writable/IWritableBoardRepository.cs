using System;
using System.Threading.Tasks;
using TodoApp.Domain.Models;

namespace TodoApp.Domain.Repositories.Abstractions.Writable
{
    public interface IWritableBoardRepository
    {
		Task<Board> AddBoardAsync(Board board);
		Task<Board> DeleteBoardAsync(Board board);
		Task<Board> UpdateBoardAsync(Board board);
	}
}
