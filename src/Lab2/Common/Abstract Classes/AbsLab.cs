using Prototype;
using Users;

namespace LearningResources.Labs;

public abstract class AbsLab : AbsLearningResource, IPrototype<AbsLab>
{
    public uint MaxPointsReward { get; init; }

    public abstract AbsLab Clone(AbsUser author, uint newId);

    public abstract AbsLab Clone();

    protected string Criterion { get; set; }

    protected AbsLab(
            uint id,
            string name,
            AbsUser author,
            string overview,
            string criterion,
            uint maxPointsReward) : base(id, name, author, overview)
    {
        this.Criterion = criterion ?? throw new ArgumentNullException(nameof(criterion));
        this.MaxPointsReward = maxPointsReward;
    }

    protected AbsLab(AbsLab other) : base(other.Id, other.Name, other.Author, other.Overview)
    {
        this.Criterion = other.Criterion;
        this.MaxPointsReward = other.MaxPointsReward;
    }
}
