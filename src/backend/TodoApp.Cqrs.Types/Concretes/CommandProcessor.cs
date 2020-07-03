using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TodoApp.Cqrs.Types.Abstract;

namespace TodoApp.Cqrs.Types.Concretes
{
	public class CommandProcessor : ICommandProcessor
	{
		protected readonly IMediator mediator;

		public CommandProcessor(IMediator mediator)
		{
			this.mediator = mediator;
		}

		public Task<TResult> Run<TResult>(ICommand<TResult> command, CancellationToken cancellationToken)
		{
			return mediator.Send(command, cancellationToken);
		}

		public Task<TResult> Run<TResult>(ICommand<TResult> command)
		{
			return this.Run(command, CancellationToken.None);
		}
	}
}
