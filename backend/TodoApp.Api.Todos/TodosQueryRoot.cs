using System;
using TodoApp.Api.Todos.Queries;
using TodoApp.GraphQL.Types;

namespace TodoApp.Api.Todos
{
	public class TodosQueryRoot : QueryRoot
	{
		public TodosQueryRoot(TodosQuery todos)
		{
			this.Todos = todos;
		}
		
		public TodosQuery Todos { get; set; }
	}
}
