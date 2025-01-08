using ResultTypes.CommandResults;

namespace FileSystems.Common;

public interface IFileSystem
{
    public ExecuteResult FileRename(string path, string name);

    public ExecuteResult FileMove(string sourcePath, string destPath);

    public ExecuteResult FileCopy(string sourcePath, string destPath);

    public ExecuteResult FileRemove(string path);

    public ExecuteResult TreeGoto(string path);

    public ExecuteResult TreeList(uint depth, char fileIcon, char dirIcon, char indentSymbol);

    public ExecuteResult FileShow(string path, string mode);
}
