using Commands.Common;
using Commands.Models;
using Flags.Common;
using Flags.Models;
using ParamHandlers.Models;
using Receivers.Common;
using Receivers.Models;
using Xunit;

namespace Tests;

public class CommandParserTests
{
    [Fact]
    public void ShouldReturnNullFlag_WhenFlagModeIsntCorrect()
    {
        var handler = new ConnectHandler();
        IReceiver receiver = new FileManager();
        string lineToBeParsed = "Connect %PATH% --q local";
        IEnumerator<string> request = ((IEnumerable<string>)lineToBeParsed.Split(" ")).GetEnumerator();
        request.MoveNext();
        ICommand? command = handler.Handle(request, receiver);
        IFlag? flag = null;

        if (command is not null)
        {
            flag = command.Handle(request);
        }

        Assert.Null(flag);
    }

    [Fact]
    public void ShouldParseCommand_WhenLineIsCurrect()
    {
        var handler = new ConnectHandler();
        IReceiver receiver = new FileManager();
        string lineToBeParsed = "Connect %PATH%";
        IEnumerator<string> request = ((IEnumerable<string>)lineToBeParsed.Split(" ")).GetEnumerator();
        request.MoveNext();
        ICommand? command = handler.Handle(request, receiver);

        if (command is not null)
            Assert.Equal(command.GetType(), new Connect(receiver, "%PATH%").GetType());
    }

    [Fact]
    public void ShouldReturnFlag_WhenFlagModeIsCorrect()
    {
        var handler = new ConnectHandler();
        IReceiver receiver = new FileManager();
        string lineToBeParsed = "Connect %PATH% --s local";
        IEnumerator<string> request = ((IEnumerable<string>)lineToBeParsed.Split(" ")).GetEnumerator();
        request.MoveNext();
        ICommand? command = handler.Handle(request, receiver);
        IFlag? flag = null;

        if (command is not null)
        {
            flag = command.Handle(request);
        }

        if (flag is not null)
            Assert.Equal(flag.GetType(), new SystemFlag("local").GetType());
    }

    [Fact]
    public void ShouldReturnDisconnectCommand_WhenLineHasDisconnect()
    {
        var handler = new DisconnectHandler();
        IReceiver receiver = new FileManager();
        string lineToBeParsed = "Disconnect";
        IEnumerator<string> request = ((IEnumerable<string>)lineToBeParsed.Split(" ")).GetEnumerator();
        request.MoveNext();
        ICommand? command = handler.Handle(request, receiver);

        if (command is not null)
            Assert.Equal(command.GetType(), new Disconnect(receiver).GetType());
    }

    [Fact]
    public void ShouldReturnFileCopyCommand_WhenLineHasFileCopy()
    {
        var handler = new FileCopyHandler();
        IReceiver receiver = new FileManager();
        string lineToBeParsed = "FileCopy %sourcepath% %destpath%";
        IEnumerator<string> request = ((IEnumerable<string>)lineToBeParsed.Split(" ")).GetEnumerator();
        request.MoveNext();
        ICommand? command = handler.Handle(request, receiver);

        if (command is not null)
            Assert.Equal(command.GetType(), new FileCopy(receiver, "%sourcepath%", "%destpath%").GetType());
    }

    [Fact]
    public void ShouldReturnFileMoveCommand_WhenLineHasFileMove()
    {
        var handler = new FileMoveHandler();
        IReceiver receiver = new FileManager();
        string lineToBeParsed = "FileCopy %sourcepath% %destpath%";
        IEnumerator<string> request = ((IEnumerable<string>)lineToBeParsed.Split(" ")).GetEnumerator();
        request.MoveNext();
        ICommand? command = handler.Handle(request, receiver);

        if (command is not null)
            Assert.Equal(command.GetType(), new FileMove(receiver, "%sourcepath%", "%destpath%").GetType());
    }

    [Fact]
    public void ShouldReturnFileRemoveCommand_WhenLineHasFileRemove()
    {
        var handler = new FileRemoveHandler();
        IReceiver receiver = new FileManager();
        string lineToBeParsed = "FileCopy %sourcepath%";
        IEnumerator<string> request = ((IEnumerable<string>)lineToBeParsed.Split(" ")).GetEnumerator();
        request.MoveNext();
        ICommand? command = handler.Handle(request, receiver);

        if (command is not null)
            Assert.Equal(command.GetType(), new FileRemove(receiver, "%sourcepath%").GetType());
    }

    [Fact]
    public void ShouldReturnFileRenameCommand_WhenLineHasFileRename()
    {
        var handler = new FileRenameHandler();
        IReceiver receiver = new FileManager();
        string lineToBeParsed = "FileRename %sourcepath% %name%";
        IEnumerator<string> request = ((IEnumerable<string>)lineToBeParsed.Split(" ")).GetEnumerator();
        request.MoveNext();
        ICommand? command = handler.Handle(request, receiver);

        if (command is not null)
            Assert.Equal(command.GetType(), new FileRename(receiver, "%sourcepath%", "%name%").GetType());
    }

    [Fact]
    public void ShouldReturnFileShowCommand_WhenLineHasFileShow()
    {
        var handler = new FileShowHandler();
        IReceiver receiver = new FileManager();
        string lineToBeParsed = "FileShow %source";
        IEnumerator<string> request = ((IEnumerable<string>)lineToBeParsed.Split(" ")).GetEnumerator();
        request.MoveNext();
        ICommand? command = handler.Handle(request, receiver);

        if (command is not null)
            Assert.Equal(command.GetType(), new FileShow(receiver, "%source%").GetType());
    }

    [Fact]
    public void ShouldReturnTreeListCommand_WhenLineHasTreeList()
    {
        var handler = new TreeListHandler();
        IReceiver receiver = new FileManager();
        string lineToBeParsed = "TreeList";
        IEnumerator<string> request = ((IEnumerable<string>)lineToBeParsed.Split(" ")).GetEnumerator();
        request.MoveNext();
        ICommand? command = handler.Handle(request, receiver);

        if (command is not null)
            Assert.Equal(command.GetType(), new TreeList(receiver).GetType());
    }

    [Fact]
    public void ShouldReturnTreeGotoCommand_WhenLineHasTreeGoto()
    {
        var handler = new TreegotoHandler();
        IReceiver receiver = new FileManager();
        string lineToBeParsed = "TreeGoto %path%";
        IEnumerator<string> request = ((IEnumerable<string>)lineToBeParsed.Split(" ")).GetEnumerator();
        request.MoveNext();
        ICommand? command = handler.Handle(request, receiver);

        if (command is not null)
            Assert.Equal(command.GetType(), new TreeGoto(receiver, "%path%").GetType());
    }
}
