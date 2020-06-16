using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Domain.Models;

namespace TodoApp.Domain.Repositories.Abstractions.Readable
{
    public interface IReadableTodoRepository
    {
		Task<bool> CheckTodoExistsAsync(string todoId);
		Task<Todo> GetTodoAsync(string todoId);
		Task<List<Todo>> GetAllTodosOfBoardAsync(string boardId);
		Task<List<Todo>> GetSubsetOfTodosOfBoardAsync(string boardId, int numberOfTodos, int numberOfTodosToSkip);
		Task<List<Todo>> GetDoneTodosOfBoardAsync(string boardId, int numberOfTodos, int numberOfTodosToSkip);
		Task<List<Todo>> GetUndoneTodosOfBoardAsync(string boardId, int numberOfTodos, int numberOfTodosToSkip);
		Task<int> GetNumberOfTodosOfBoardAsync(string boardId);
		Task<int> GetNumberOfDoneTodosOfBoardAsync(string boardId);
		Task<int> GetNumberOfUndoneTodosOfBoardAsync(string boardId);
	}
}
