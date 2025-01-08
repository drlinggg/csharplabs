namespace Repositories;

public abstract record TryRemoveResult
{
    private TryRemoveResult() { }

    public sealed record Success() : TryRemoveResult;

    public sealed record FailureNoSuchID(uint Id) : TryRemoveResult;
}
