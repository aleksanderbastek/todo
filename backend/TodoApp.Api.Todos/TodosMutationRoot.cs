using System;
using TodoApp.Api.Todos.Mutations;
using TodoApp.GraphQL.Types;

namespace TodoApp.Api.Todos
{
	public class TodosMutationRoot : MutationRoot
	{
		public TodosMutationRoot(TodosMutation todos)
		{
			this.Todos = todos;
		}

		public TodosMutation Todos { get; set; }
	}
}
