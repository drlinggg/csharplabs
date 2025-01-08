using Subjects;
using Users;

namespace Programs;

public class ProgramBuilder : IProgramBuilder
{
    public AbsUser? Author { get; private set; }

    // all Id are in [1;4 294 967 295]
    public uint Id { get; set; } = 1;

    private string? name;

    private Dictionary<Semester, List<AbsSubject>>? subjects;

    public IProgramBuilder WithName(string name)
    {
        this.name = name;
        return this;
    }

    public IProgramBuilder WithAuthor(AbsUser author)
    {
        this.Author = author;
        return this;
    }

    public IProgramBuilder WithSubjects(Dictionary<Semester, List<AbsSubject>> subjects)
    {
        this.subjects = subjects;
        return this;
    }

    public AbsProgram GetResult()
    {
        return new Program(
                Id++,
                name ?? throw new ArgumentNullException(),
                Author ?? throw new ArgumentNullException(),
                subjects ?? throw new ArgumentNullException());
    }
}
