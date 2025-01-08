using Messages;

namespace Loggers;

public class MessageFileLogger : ILogger
{
    private const string LogFilePath = "./";

    public void Log(IMessage message)
    {
        string text = message.Header + "\n" + message.Body + "\n";
        text += DateTime.Now.ToString("HH:mm:ss");
        StreamWriter writer = File.AppendText(LogFilePath);
        writer.WriteLine(text);
    }
}
