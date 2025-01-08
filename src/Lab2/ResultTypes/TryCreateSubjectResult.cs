namespace Subjects;

public abstract record TryCreateSubjectResult
{
    private TryCreateSubjectResult() { }

    public sealed record Success(AbsSubject Entity) : TryCreateSubjectResult;

    public sealed record SummOfPointsIsntCorrect(uint Points) : TryCreateSubjectResult;
}
