using Assessments;
using Identifiable;
using LearningResources.Labs;
using LearningResources.Lectures;
using Prototype;
using Users;

namespace Subjects;

// убрать паблик на протектед
public abstract class AbsSubject : IIdentifiable, IPrototype<AbsSubject>
{
    public uint Id { get; protected set; }

    // all id are in [1;4 294 967 295], so 0 means no origin
    public uint OriginId { get; protected set; } = 0;

    public AbsUser Author { get; protected set; }

    public Dictionary<uint, AbsLab> Labs { get; init; }

    protected string Name { get; set; }

    protected Dictionary<uint, AbsLecture> Lectures { get; init; }

    protected AbsAssessment? Assessment { get; set; }

    public abstract AbsSubject Clone();

    public abstract AbsSubject Clone(AbsUser author, uint newId);

    public abstract AbsAssessment CreateAssesment(uint points);

    protected AbsSubject(
            uint id,
            string name,
            AbsUser author,
            Dictionary<uint, AbsLecture> lectures,
            Dictionary<uint, AbsLab> labs)
    {
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Id = id;
        this.Author = author ?? throw new ArgumentNullException(nameof(author));
        this.Labs = labs ?? throw new ArgumentNullException(nameof(author));
        this.Lectures = lectures ?? throw new ArgumentNullException(nameof(lectures));
    }
}
