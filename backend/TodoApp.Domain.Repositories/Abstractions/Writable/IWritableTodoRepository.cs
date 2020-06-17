using System;
using System.Threading.Tasks;
using TodoApp.Domain.Models;

namespace TodoApp.Domain.Repositories.Abstractions.Writable
{
    public interface IWritableTodoRepository
    {
		Task<Todo> AddTodoAsync(Todo todo);
		Task<Todo> RemoveTodoAsync(Todo todo);
		Task<Todo> UpdateTodoAsync(Todo todo);
		Task<Todo> UpdateTodoTitleAsync(Todo todo);
		Task<Todo> UpdateTodoDeadlineAsync(Todo todo);
		Task<Todo> UpdateTodoDoneDateAsync(Todo todo);
	}
}
