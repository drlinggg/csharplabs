using Messages;
using Users;

namespace Addressees;

public class AddresseeUser : IAddressee
{
    private readonly User _user;

    public AddresseeUser(User user)
    {
        _user = user;
    }

    public GetMessageResult GetMessage(IMessage message)
    {
        _user.AddMessage(message);
        return new GetMessageResult.Success();
    }
}
