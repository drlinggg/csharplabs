using Messages;
using System.Drawing;

namespace DisplayDrivers;

public class FileDisplayDriver : IDisplayDriver
{
    private string _filePath;

    public void Clear()
    {
        File.Create(_filePath).Close();
    }

    public void ChangeFilePath(string filepath)
    {
        _filePath = filepath;
    }

    public FileDisplayDriver(string filepath)
    {
        _filePath = filepath;
    }

    public void WriteMessage(IMessage message)
    {
        string messageText = message.Header + "\n" + message.Body + "\n" + message.LevelOfImportance;
        StreamWriter writer = File.AppendText(_filePath);
        writer.WriteLine(messageText);
    }

    public void ChangeColor(Color color) { }
}
