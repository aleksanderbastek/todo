using System.Threading;
using System;
using System.Threading.Tasks;

namespace TodoApp.Cqrs.Types.Abstract
{
	public interface ICommandProcessor
	{
		Task<TResult> Run<TResult>(ICommand<TResult> command);
		Task<TResult> Run<TResult>(ICommand<TResult> command, CancellationToken cancellationToken);
	}
}
