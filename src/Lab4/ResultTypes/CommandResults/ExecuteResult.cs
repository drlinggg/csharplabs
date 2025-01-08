namespace ResultTypes.CommandResults;

public abstract record ExecuteResult
{
    private ExecuteResult() { }

    public sealed record Success : ExecuteResult;

    public sealed record FailureInvalidArgument : ExecuteResult;

    public sealed record FailureToConnectAlreadyConnected : ExecuteResult;

    public sealed record FailureToDisconnectAlreadyDisconnected : ExecuteResult;

    public sealed record FailureNoConnect : ExecuteResult;

    public sealed record UnknowFailure : ExecuteResult;

    public sealed record FailureNoSuchFile : ExecuteResult;
}
