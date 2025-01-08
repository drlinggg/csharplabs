using Messages;
using System.Drawing;

namespace DisplayDrivers;

public interface IDisplayDriver
{
    public void Clear();

    public void ChangeColor(Color color);

    public void WriteMessage(IMessage message);
}
