using Messages;

namespace Loggers;

public interface ILogger
{
    public void Log(IMessage message);
}
