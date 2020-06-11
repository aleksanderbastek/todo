namespace TodoApp.GraphQL.Hello.Providers
{
	public class TestingHelloWordProvider : ITestingHelloWordProvider
	{
		public string HelloWord { get; set; } = "Hello";
	}
}
