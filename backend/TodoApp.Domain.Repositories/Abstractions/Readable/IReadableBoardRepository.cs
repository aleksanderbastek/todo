using System;
using System.Threading.Tasks;
using TodoApp.Domain.Models;

namespace TodoApp.Domain.Repositories.Abstractions.Readable
{
    public interface IReadableBoardRepository
    {
		Task<Board> GetBoardInfoByIdAsync(string boardId);
		Task<bool> CheckBoardExistsAsync(string boardId);
	}
}
