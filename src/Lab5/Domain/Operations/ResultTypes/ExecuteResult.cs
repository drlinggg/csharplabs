namespace Domain.Operations.ResultTypes;

public abstract record ExecuteResult
{
    private ExecuteResult() { }

    public sealed record Success : ExecuteResult;

    public sealed record FailureInvalidArgument : ExecuteResult;

    public sealed record UnknowFailure : ExecuteResult;
}
