using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.Cqrs.Types.Concretes
{
	public class QueryProcessor : IQueryProcessor
	{
		protected readonly IMediator mediator;

		public QueryProcessor(IMediator mediator)
		{
			this.mediator = mediator;
		}

		public Task<TResult> Query<TResult>(IQuery<TResult> query, CancellationToken cancellationToken)
		{
			return mediator.Send(query, cancellationToken);
		}

		public Task<TResult> Query<TResult>(IQuery<TResult> query)
		{
			return this.Query(query, CancellationToken.None);
		}
	}
}
