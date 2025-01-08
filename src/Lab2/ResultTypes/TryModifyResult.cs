using Users;

namespace Repositories;

public abstract record TryModifyResult
{
    private TryModifyResult() { }

    public sealed record Success() : TryModifyResult;

    public sealed record FailureNoEntityWithSameId(uint Id) : TryModifyResult;

    public sealed record FailureModifierIsntAuthor(AbsUser Modifier) : TryModifyResult;

    public sealed record FailureHasDifferentLabs() : TryModifyResult;

    public sealed record UknownFailure() : TryModifyResult;
}
