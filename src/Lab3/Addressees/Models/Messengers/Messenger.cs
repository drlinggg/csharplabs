using Messages;

namespace Addressees;

public class Messenger : IAddressee
{
    public GetMessageResult GetMessage(IMessage message)
    {
        Console.WriteLine("MESSENGER:");
        Console.WriteLine(message.Header);
        Console.WriteLine(message.Body);
        Console.WriteLine(message.LevelOfImportance + "\n");
        return new GetMessageResult.Success();
    }
}
