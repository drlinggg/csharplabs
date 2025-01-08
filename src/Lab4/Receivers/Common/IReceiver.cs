using ResultTypes.CommandResults;

namespace Receivers.Common;

public interface IReceiver
{
    public ExecuteResult Connect(string address, string mode);

    public ExecuteResult Disconnect();

    public ExecuteResult FileRename(string path, string name);

    public ExecuteResult FileMove(string sourcePath, string destPath);

    public ExecuteResult FileCopy(string sourcePath, string destPath);

    public ExecuteResult FileRemove(string path);

    public ExecuteResult TreeGoto(string path);

    public ExecuteResult TreeList(uint depth, char fileIcon, char dirIcon, char indentSymbol);

    public ExecuteResult FileShow(string path, string mode);
}
