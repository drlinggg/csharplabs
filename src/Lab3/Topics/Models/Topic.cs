using Addressees;
using Messages;
using System.Collections.ObjectModel;

namespace Topics;

public class Topic
{
    public string Name { get; init; }

    private readonly Collection<IAddressee> _addressees = new Collection<IAddressee>();

    public void Post(IMessage message)
    {
        foreach (IAddressee subscriber in _addressees)
        {
            subscriber.GetMessage(message);
        }
    }

    public void AddAddressee(IAddressee newAddressee)
    {
        _addressees.Add(newAddressee);
    }

    public Topic(Collection<IAddressee> subs, string name)
    {
        foreach (IAddressee sub in subs)
        {
            AddAddressee(sub);
        }

        Name = name;
    }

    public Topic(string name)
    {
        Name = name;
    }
}
