using System;
using HotChocolate.Types;
using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.GraphQL.Types
{
	public class Query
	{
		public Query(IQueryProcessor processor)
		{
			this.processor = processor;
		}

		protected IQueryProcessor processor { get; private set; }
	}
}
