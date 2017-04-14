using Common.CQRSlite.Messages;

namespace Common.CQRSlite.Commands
{
	public interface ICommand : IMessage
	{
		int ExpectedVersion { get; set; }
	}
}
