using Identifiable;
using Subjects;
using Users;

namespace Programs;

public abstract class AbsProgram : IIdentifiable
{
    public uint Id { get; init; }

    protected string Name { get; set; }

    protected AbsUser Author { get; set; }

    protected Dictionary<Semester, List<AbsSubject>> Subjects { get; init; }

    protected AbsProgram(uint id, string name, AbsUser author, Dictionary<Semester, List<AbsSubject>> subjects)
    {
        this.Id = id;
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Author = author ?? throw new ArgumentNullException(nameof(author));
        this.Subjects = subjects ?? throw new ArgumentNullException(nameof(subjects));
    }
}
