using HotChocolate;
using HotChocolate.Types;

namespace TodoApp.GraphQL.Hello.Queries
{
    [ExtendObjectType(Name = "Query")]
    public class HelloQuery
    {
        /// <summary>
        /// Should return "Hello world! :)" string.
        /// </summary>
        /// <returns>"Hello world! :)" string.</returns>
        public string SayHelloWorld() => "Hello world! :)";

        /// <summary>
        /// Returns Hello string for specified person.
        /// Hello string can be changed using changeHelloWord mutation.
        /// </summary>
        /// <param name="name">Name of person we want to say hello to.</param>
        /// <returns>"Hello ${person}!" string. Ex: "Hello Janusz!"</returns>
        public string SayHelloFor(string name, [Service] ITestingHelloWordProvider provider) => $"{provider.HelloWord} {name}!";
    }
}
