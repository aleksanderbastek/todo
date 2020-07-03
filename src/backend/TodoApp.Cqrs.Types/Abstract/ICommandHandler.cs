using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace TodoApp.Cqrs.Types.Abstract
{
	public interface ICommandHandler<TCommand>: IRequestHandler<TCommand>
		where TCommand: ICommand
	{
	}
	
	public interface ICommandHandler<TCommand, TCommandResult> : IRequestHandler<TCommand, TCommandResult>
		where TCommand : ICommand<TCommandResult>
	{
	}
}
