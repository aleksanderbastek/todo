using TodoApp.GraphQL.Hello.Mutations;
using TodoApp.GraphQL.Types;

namespace TodoApp.GraphQL.Hello.Roots
{
	public class HelloMutationRoot : MutationRoot
	{
		public string Data() => "data";
	}
}
