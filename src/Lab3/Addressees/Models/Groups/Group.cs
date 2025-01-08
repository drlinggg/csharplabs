using Messages;
using System.Collections.ObjectModel;

namespace Addressees;

public class Group : IAddressee
{
    private readonly Collection<IAddressee> _addressees = new Collection<IAddressee>();

    public GetMessageResult GetMessage(IMessage message)
    {
        foreach (IAddressee subscriber in _addressees)
        {
            GetMessageResult res = subscriber.GetMessage(message);
        }

        return new GetMessageResult.Success();
    }

    public void AddAddressee(IAddressee newAddressee)
    {
        _addressees.Add(newAddressee);
    }

    public Group(Collection<IAddressee> addressees)
    {
        foreach (IAddressee subscriber in addressees)
        {
            AddAddressee(subscriber);
        }
    }

    public Group() { }
}
