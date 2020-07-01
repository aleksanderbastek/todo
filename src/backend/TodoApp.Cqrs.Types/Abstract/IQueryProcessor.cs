using System;
using System.Threading;
using System.Threading.Tasks;

namespace TodoApp.Cqrs.Types.Abstract
{
	public interface IQueryProcessor
	{
		Task<TResult> Query<TResult>(IQuery<TResult> query);
		Task<TResult> Query<TResult>(IQuery<TResult> query, CancellationToken cancellationToken);
	}
}
