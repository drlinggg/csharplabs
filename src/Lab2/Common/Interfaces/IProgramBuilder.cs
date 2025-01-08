using Subjects;
using Users;

namespace Programs;

public interface IProgramBuilder
{
    public uint Id { get; set; }

    public IProgramBuilder WithName(string name);

    public IProgramBuilder WithAuthor(AbsUser author);

    public IProgramBuilder WithSubjects(Dictionary<Semester, List<AbsSubject>> subjects);

    public AbsProgram GetResult();
}
