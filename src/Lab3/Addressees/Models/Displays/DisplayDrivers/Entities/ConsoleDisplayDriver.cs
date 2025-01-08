using Messages;
using System.Drawing;
using Console = System.Console;

namespace DisplayDrivers;

public class ConsoleDisplayDriver : IDisplayDriver
{
    private Color _currentColor;

    public void Clear()
    {
        Console.Clear();
    }

    public void ChangeColor(Color color)
    {
        _currentColor = color;
    }

    public ConsoleDisplayDriver(Color color)
    {
        ChangeColor(color);
    }

    public void WriteMessage(IMessage message)
    {
        string messageText = message.Header + "\n" + message.Body + "\n" + message.LevelOfImportance;
        string text = Crayon.Output.Rgb(_currentColor.R, _currentColor.G, _currentColor.B).Text(messageText);
        Console.ResetColor();
    }
}
