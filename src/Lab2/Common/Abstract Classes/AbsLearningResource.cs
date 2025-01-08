using Identifiable;
using Users;

namespace LearningResources;

public abstract class AbsLearningResource : IIdentifiable
{
    public uint Id { get; protected set; }

    // all id are in [1;4 294 967 295], so 0 means no origin
    public uint OriginId { get; protected set; } = 0;

    public AbsUser Author { get; protected set; }

    protected string Name { get; set; }

    protected string Overview { get; set; }

    protected AbsLearningResource(uint id, string name, AbsUser author, string overview)
    {
        this.Id = id;
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Author = author ?? throw new ArgumentNullException(nameof(author));
        this.Overview = overview ?? throw new ArgumentNullException(nameof(overview));
    }
}
