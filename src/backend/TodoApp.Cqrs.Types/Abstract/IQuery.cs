using MediatR;

namespace TodoApp.Cqrs.Types.Abstract
{
	public interface IQuery<TResult> : IRequest<TResult>
	{
	}
}
