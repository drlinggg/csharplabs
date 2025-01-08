namespace Domain.Contracts.Users.ResultTypes;

public abstract record LoginResult
{
    private LoginResult() { }

    public sealed record Success : LoginResult;

    public sealed record NotFound : LoginResult;

    public sealed record Failure : LoginResult;
}
