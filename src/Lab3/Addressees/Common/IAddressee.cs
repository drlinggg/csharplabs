using Messages;

namespace Addressees;

public interface IAddressee
{
    public GetMessageResult GetMessage(IMessage message);
}
