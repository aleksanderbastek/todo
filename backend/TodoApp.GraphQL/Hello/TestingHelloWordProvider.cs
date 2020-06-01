namespace TodoApp.GraphQL.Hello
{
	public class TestingHelloWordProvider : ITestingHelloWordProvider
	{
		public string HelloWord { get; set; } = "Hello";
	}
}
