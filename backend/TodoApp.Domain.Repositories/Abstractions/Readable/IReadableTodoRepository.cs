using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Domain.Models;

namespace TodoApp.Domain.Repositories.Abstractions.Readable
{
    public interface IReadableTodoRepository
    {
		Task<bool> CheckTodoExistsAsync(Todo todo);
		Task<bool> CheckTodoExistsAsync(string todoId);
		Task<List<Todo>> GetAllTodosOfBoardAsync(Board board);
		Task<List<Todo>> GetAllTodosOfBoardAsync(string boardId);
		Task<List<Todo>> GetSubsetOfTodosOfBoardAsync(Board board, int numberOfTodos, int numberOfTodosToSkip);
		Task<List<Todo>> GetSubsetOfTodosOfBoardAsync(string boardId, int numberOfTodos, int numberOfTodosToSkip);
		Task<int> GetNumberOfTodosOfBoardAsync(Board board);
		Task<int> GetNumberOfTodosOfBoardAsync(string boardId);
	}
}
