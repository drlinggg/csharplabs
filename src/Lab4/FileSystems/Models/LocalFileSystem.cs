using FileSystems.Common;
using ResultTypes.CommandResults;

namespace FileSystems.Models;

public class LocalFileSystem : IFileSystem
{
    private string _root;

    public LocalFileSystem(string root)
    {
        _root = root;
    }

    public ExecuteResult FileRename(string path, string name)
    {
        path = GetFullPath(path);

        var fileInf = new FileInfo(path);
        if (!fileInf.Exists)
            return new ExecuteResult.FailureNoSuchFile();

        string? directory = fileInf.DirectoryName;
        if (directory is null)
        {
            return new ExecuteResult.FailureInvalidArgument();
        }

        string newFilePath = Path.Combine(directory, name);
        return FileMove(path, newFilePath);
    }

    public ExecuteResult FileMove(string sourcePath, string destPath)
    {
        sourcePath = GetFullPath(sourcePath);
        destPath = GetFullPath(destPath);

        var fileInf = new FileInfo(sourcePath);
        if (!fileInf.Exists)
            return new ExecuteResult.FailureNoSuchFile();

        fileInf.MoveTo(destPath, true);
        return new ExecuteResult.Success();
    }

    public ExecuteResult FileCopy(string sourcePath, string destPath)
    {
        sourcePath = GetFullPath(sourcePath);
        destPath = GetFullPath(destPath);

        var fileInf = new FileInfo(sourcePath);
        if (!fileInf.Exists)
            return new ExecuteResult.FailureNoSuchFile();

        fileInf.CopyTo(destPath, true);
        return new ExecuteResult.Success();
    }

    public ExecuteResult FileRemove(string path)
    {
        path = GetFullPath(path);

        var fileInf = new FileInfo(path);
        if (!fileInf.Exists)
            return new ExecuteResult.FailureNoSuchFile();

        fileInf.Delete();
        return new ExecuteResult.Success();
    }

    public ExecuteResult TreeGoto(string path)
    {
        path = GetFullPath(path);
        _root = path;
        return new ExecuteResult.Success();
    }

    public ExecuteResult FileShow(string path, string mode)
    {
        path = GetFullPath(path);
        if (!File.Exists(path))
        {
            return new ExecuteResult.FailureNoSuchFile();
        }

        switch (mode)
        {
            case "console":
                string readText = File.ReadAllText(path);
                Console.WriteLine(readText);
                return new ExecuteResult.Success();

            default:
                return new ExecuteResult.FailureInvalidArgument();
        }
    }

    public ExecuteResult TreeList(uint depth, char fileIcon, char dirIcon, char indentSymbol)
    {
        string path = _root;
        var result = new List<string>();
        ExploreDirectory(path, depth, 0, result, fileIcon, dirIcon, indentSymbol);

        foreach (string item in result)
        {
            Console.WriteLine(item);
        }

        return new ExecuteResult.Success();
    }

    private void ExploreDirectory(string path, uint maxDepth, uint currentDepth, List<string> result, char fileIcon, char dirIcon, char indentSymbol)
    {
        if (currentDepth > maxDepth) return;

        var directoryInfo = new DirectoryInfo(path);
        DirectoryInfo[] directories = directoryInfo.GetDirectories();
        FileInfo[] files = directoryInfo.GetFiles();

        string indent = new string(indentSymbol, (int)currentDepth * 5);

        foreach (DirectoryInfo dir in directories)
        {
            result.Add($"{indent}{dirIcon}{dir.Name}");
            ExploreDirectory(dir.FullName, maxDepth, currentDepth + 1, result, fileIcon, dirIcon, indentSymbol);
        }

        foreach (FileInfo file in files)
        {
            result.Add($"{indent}{fileIcon}{file.Name}");
        }
    }

    private bool IsAbsolutePath(string path)
    {
        return Path.IsPathRooted(path);
    }

    private string GetFullPath(string path)
    {
        if (IsAbsolutePath(path))
        {
            return path;
        }
        else
        {
            return _root + "/" + path;
        }
    }
}
