using System;

namespace TodoApp.GraphQL.Hello.Mutations.Models
{
	public class ChangeHelloWordResult {
		public string NewName { get; set; }
		public bool Success { get; set; }
	}
}
