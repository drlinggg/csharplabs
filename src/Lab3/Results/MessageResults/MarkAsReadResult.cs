namespace Users;

public abstract record MarkAsReadResult
{
    private MarkAsReadResult() { }

    public sealed record Success() : MarkAsReadResult;

    public sealed record FailureHasAlreadyBeenRead(Guid Id) : MarkAsReadResult;

    public sealed record FailureNoSuchMessage(Guid Id) : MarkAsReadResult;

    public sealed record UknownFailure() : MarkAsReadResult;
}
