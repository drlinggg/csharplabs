namespace Addressees;

public abstract record GetMessageResult
{
    private GetMessageResult() { }

    public sealed record Success() : GetMessageResult;

    public sealed record FailureImportanceBelowRequired() : GetMessageResult;

    public sealed record UknownFailure() : GetMessageResult;
}
