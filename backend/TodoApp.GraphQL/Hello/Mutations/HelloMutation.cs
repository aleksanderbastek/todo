using HotChocolate;
using TodoApp.GraphQL.Hello.Mutations.Models;
using TodoApp.GraphQL.Types;

namespace TodoApp.GraphQL.Hello.Mutations
{
    public class HelloMutation: Mutation
    {
		/// <summary>
		/// Changes "Hello" word used in sayHelloFor query.
		/// </summary>
		/// <param name="newName">The new name of "Hello" word. You can use "dupa" for example.</param>
		/// <returns>Whether name is changed correctly. It means: always true, because there is no database yet xD</returns>
		public ChangeHelloWordResult ChangeHelloWord(string newName, [Service] ITestingHelloWordProvider provider)
		{
			provider.HelloWord = newName;

			return new ChangeHelloWordResult()
			{
				NewName = newName,
				Success = true
			};
		}
    }
}
