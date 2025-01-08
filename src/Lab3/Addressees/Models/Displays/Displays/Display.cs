using DisplayDrivers;
using Messages;
using System.Drawing;

namespace Addressees;

public class Display : IAddressee
{
    private IDisplayDriver _displayDriver;

    public void ChangeColor(Color color)
    {
        _displayDriver.ChangeColor(color);
    }

    public GetMessageResult GetMessage(IMessage message)
    {
        WriteMessage(message);
        return new GetMessageResult.Success();
    }

    public Display(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void ChangeDriver(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    private void WriteMessage(IMessage message)
    {
        _displayDriver.Clear();
        _displayDriver.WriteMessage(message);
    }
}
