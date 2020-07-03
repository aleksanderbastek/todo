using System;
using HotChocolate.Types;
using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.GraphQL.Types
{
	public class Mutation
	{
		public Mutation(ICommandProcessor processor)
		{
			this.processor = processor;
		}
		
		protected ICommandProcessor processor { get; private set; }
	}
}
