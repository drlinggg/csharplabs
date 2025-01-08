namespace Repositories;

public abstract record TryAddResult
{
    private TryAddResult() { }

    public sealed record Success() : TryAddResult;

    public sealed record FailureAlreadyContainsID(uint Id) : TryAddResult;

    public sealed record FailureCouldntCreateBeforeAdding() : TryAddResult;

    public sealed record FailureCouldntCopyBeforeAdding() : TryAddResult;
}
