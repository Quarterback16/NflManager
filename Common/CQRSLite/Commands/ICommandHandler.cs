using Common.CQRSlite.Messages;

namespace Common.CQRSlite.Commands
{
	public interface ICommandHandler<in T> : IHandler<T> where T : ICommand
	{
	}
}
