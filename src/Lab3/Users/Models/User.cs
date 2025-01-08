using Messages;

namespace Users;

public class User
{
    private readonly Dictionary<Guid, IMessage> uncheckedMessages = new Dictionary<Guid, IMessage>();

    private readonly Dictionary<Guid, IMessage> checkedMessages = new Dictionary<Guid, IMessage>();

    public void AddMessage(IMessage message)
    {
        if (uncheckedMessages.ContainsKey(message.Id))
        {
            return;
        }

        uncheckedMessages.Add(message.Id, message);
    }

    public MarkAsReadResult MarkAsRead(Guid id)
    {
        if (!uncheckedMessages.ContainsKey(id))
        {
            if (checkedMessages.ContainsKey(id))
                return new MarkAsReadResult.FailureHasAlreadyBeenRead(id);
            else
                return new MarkAsReadResult.FailureNoSuchMessage(id);
        }

        IMessage checkedMessage = uncheckedMessages[id];
        uncheckedMessages.Remove(id);
        checkedMessages.Add(checkedMessage.Id, checkedMessage);
        return new MarkAsReadResult.Success();
    }

    public IMessage? FindMessage(Guid id)
    {
        if (uncheckedMessages.ContainsKey(id))
        {
            return uncheckedMessages[id];
        }

        if (checkedMessages.ContainsKey(id))
        {
            return checkedMessages[id];
        }

        return null;
    }
}
