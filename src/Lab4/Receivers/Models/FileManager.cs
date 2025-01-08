using ConnectionStates.Models;
using FileSystems.Common;
using FileSystems.Models;
using Receivers.Common;
using ResultTypes.CommandResults;

namespace Receivers.Models;

public class FileManager : IReceiver
{
    private FileSystemConnectionState _state = FileSystemConnectionState.Closed;

    private IFileSystem? _fileSystem = null;

    public ExecuteResult Connect(string address, string mode)
    {
        if (_state != FileSystemConnectionState.Closed)
            return new ExecuteResult.FailureToConnectAlreadyConnected();

        switch (mode)
        {
            case "local":
                _fileSystem = new LocalFileSystem(address);
                break;

            default:
                return new ExecuteResult.FailureInvalidArgument();
        }

        _state = FileSystemConnectionState.Opened;
        return new ExecuteResult.Success();
    }

    public ExecuteResult Disconnect()
    {
        if (_state != FileSystemConnectionState.Opened)
            return new ExecuteResult.FailureToDisconnectAlreadyDisconnected();

        _state = FileSystemConnectionState.Closed;
        _fileSystem = null;
        return new ExecuteResult.Success();
    }

    public ExecuteResult FileRename(string path, string name)
    {
        if (_state != FileSystemConnectionState.Opened)
            return new ExecuteResult.FailureNoConnect();

        if (_fileSystem is null)
            return new ExecuteResult.UnknowFailure();

        return _fileSystem.FileRename(path, name);
    }

    public ExecuteResult FileMove(string sourcePath, string destPath)
    {
        if (_state != FileSystemConnectionState.Opened)
            return new ExecuteResult.FailureNoConnect();

        if (_fileSystem is null)
            return new ExecuteResult.UnknowFailure();

        return _fileSystem.FileMove(sourcePath, destPath);
    }

    public ExecuteResult FileCopy(string sourcePath, string destPath)
    {
        if (_state != FileSystemConnectionState.Opened)
            return new ExecuteResult.FailureNoConnect();

        if (_fileSystem is null)
            return new ExecuteResult.UnknowFailure();

        return _fileSystem.FileCopy(sourcePath, destPath);
    }

    public ExecuteResult FileRemove(string path)
    {
        if (_state != FileSystemConnectionState.Opened)
            return new ExecuteResult.FailureNoConnect();

        if (_fileSystem is null)
            return new ExecuteResult.UnknowFailure();

        return _fileSystem.FileRemove(path);
    }

    public ExecuteResult TreeGoto(string path)
    {
        if (_state != FileSystemConnectionState.Opened)
            return new ExecuteResult.FailureNoConnect();

        if (_fileSystem is null)
            return new ExecuteResult.UnknowFailure();

        return _fileSystem.TreeGoto(path);
    }

    public ExecuteResult TreeList(uint depth, char fileIcon, char dirIcon, char indentSymbol)
    {
        if (_state != FileSystemConnectionState.Opened)
            return new ExecuteResult.FailureNoConnect();

        if (_fileSystem is null)
            return new ExecuteResult.UnknowFailure();

        return _fileSystem.TreeList(depth, fileIcon, dirIcon, indentSymbol);
    }

    public ExecuteResult FileShow(string path, string mode)
    {
        if (_state != FileSystemConnectionState.Opened)
            return new ExecuteResult.FailureNoConnect();

        if (_fileSystem is null)
            return new ExecuteResult.UnknowFailure();

        return _fileSystem.FileShow(path, mode);
    }

    public FileManager(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public FileManager() { }
}
