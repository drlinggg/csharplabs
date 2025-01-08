namespace ResultTypes;

public abstract record TryPassResult
{
    private TryPassResult() { }

    public sealed record Success : TryPassResult;

    public sealed record InabilityToOvercomeDist : TryPassResult;

    public sealed record MaxForceExceeded(float MaxForce) : TryPassResult;

    public sealed record MaxSpeedExceeded(float Speed) : TryPassResult;
}
