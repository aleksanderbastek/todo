using TodoApp.GraphQL.Hello.Queries;
using TodoApp.GraphQL.Types;

namespace TodoApp.GraphQL.Hello.Roots
{
	public class HelloQueryRoot : QueryRoot
	{
		public HelloQueryRoot(HelloQuery hello, UserQuery user, HelloCqrs cqrs)
		{
			this.Hello = hello;
			this.User = user;
			this.Cqrs = cqrs;
		}

		public HelloQuery Hello { get; set; }
		public UserQuery User { get; set; }
		public HelloCqrs Cqrs { get; set; }

		public string JustHello() => "Hello!";
	}
}
