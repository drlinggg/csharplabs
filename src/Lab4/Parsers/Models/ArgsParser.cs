using Commands.Common;
using Flags.Common;
using ParamHandlers.Common;
using ParamHandlers.Models;
using Receivers.Common;

namespace Parsers.Models;

public class ArgsParser
{
    private readonly IReceiver _fileManager;

    private readonly IParamHandler _handler = new ConnectHandler()
            .AddNext(new DisconnectHandler())
            .AddNext(new FileCopyHandler())
            .AddNext(new FileMoveHandler())
            .AddNext(new FileShowHandler())
            .AddNext(new FileRemoveHandler())
            .AddNext(new FileRenameHandler())
            .AddNext(new TreeListHandler())
            .AddNext(new TreegotoHandler());

    public ArgsParser(IReceiver fileManager)
    {
        _fileManager = fileManager;
    }

    public void Parse(string[] args)
    {
        IEnumerator<string> request = ((IEnumerable<string>)args).GetEnumerator();
        bool readyToPickNext = true;
        ICommand? command = null;
        while (true)
        {
            if (readyToPickNext)
            {
                if (request.MoveNext() == false)
                    break;
            }

            command = _handler.Handle(request, _fileManager);

            if (request.MoveNext() == false)
                break;

            readyToPickNext = true;
            if (command is null)
            {
                continue;
            }

            IFlag? flag = command.Handle(request);

            if (request.MoveNext() == false)
                break;

            while (flag is not null)
            {
                flag = command.Handle(request);
                if (flag is null)
                {
                    readyToPickNext = false;
                    break;
                }

                if (request.MoveNext() == false)
                    break;
            }

            command.Execute();
        }

        if (command is not null)
            command.Execute();
    }
}
