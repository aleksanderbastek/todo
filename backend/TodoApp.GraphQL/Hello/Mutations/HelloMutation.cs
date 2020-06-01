using System;
using HotChocolate;
using HotChocolate.Types;
using TodoApp.GraphQL.Hello.Mutations.Models;

namespace TodoApp.GraphQL.Hello.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class HelloMutation
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
