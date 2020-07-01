using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace TodoApp.Cqrs.Types.Abstract
{
	public interface IQueryHandler<TQuery, TQueryResult> : IRequestHandler<TQuery, TQueryResult>
		where TQuery : IQuery<TQueryResult>
	{
	}
}
