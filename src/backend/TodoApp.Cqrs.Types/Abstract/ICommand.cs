using System;
using MediatR;

namespace TodoApp.Cqrs.Types.Abstract
{
	public interface ICommand: IRequest
	{
	}

	public interface ICommand<TResult> : IRequest<TResult>
	{
	}
}
