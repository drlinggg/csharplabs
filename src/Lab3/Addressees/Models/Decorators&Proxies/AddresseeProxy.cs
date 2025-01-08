using Importances;
using Messages;

namespace Addressees;

public class AddresseeProxy : IAddressee
{
    private readonly IAddressee _original;

    private ImportanceLevel _filter;

    public AddresseeProxy(IAddressee original, ImportanceLevel filter)
    {
        _original = original;
        _filter = filter;
    }

    public AddresseeProxy WithFilter(ImportanceLevel filter)
    {
        _filter = filter;
        return this;
    }

    public GetMessageResult GetMessage(IMessage message)
    {
        if (message.LevelOfImportance < _filter)
        {
            return new GetMessageResult.FailureImportanceBelowRequired();
        }

        return _original.GetMessage(message);
    }
}
