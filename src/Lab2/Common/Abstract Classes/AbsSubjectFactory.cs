using LearningResources.Labs;
using LearningResources.Lectures;
using Users;

namespace Subjects;

public abstract class AbsSubjectFactory
{
    // all id are in [1;4 294 967 295]
    public uint Id { get; set; } = 1;

    public uint Points { get; set; } = 30;

    public string? Name { get; set; }

    public AbsUser? Creator { get; set; }

    public Dictionary<uint, AbsLecture> Lectures { get; init; } = new Dictionary<uint, AbsLecture>();

    public Dictionary<uint, AbsLab> Labs { get; init; } = new Dictionary<uint, AbsLab>();

    public abstract TryCreateSubjectResult CreateSubject();

    protected AbsSubjectFactory() { }

    protected AbsSubjectFactory(
            uint id,
            string name,
            AbsUser creator,
            Dictionary<uint, AbsLecture> lectures,
            Dictionary<uint, AbsLab> labs)
    {
        this.Id = id;
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Creator = creator ?? throw new ArgumentNullException(nameof(creator));
        this.Lectures = lectures ?? throw new ArgumentNullException(nameof(lectures));
        this.Labs = labs ?? throw new ArgumentNullException(nameof(labs));
    }
}
