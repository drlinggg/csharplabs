using Loggers;
using Messages;

namespace Addressees;

public class LoggingAddresseeDecorator : IAddressee
{
    private readonly IAddressee _decoratee;

    private readonly ILogger _logger;

    public LoggingAddresseeDecorator(IAddressee dec, ILogger log)
    {
        _decoratee = dec;
        _logger = log;
    }

    public GetMessageResult GetMessage(IMessage message)
    {
        _logger.Log(message);
        return _decoratee.GetMessage(message);
    }
}
