using Users;

namespace LearningResources.Labs;

public interface ILabBuilder
{
    public AbsUser? User { get; }

    public uint Id { get; set; }

    public ILabBuilder WithName(string name);

    public ILabBuilder WithAuthor(AbsUser user);

    public ILabBuilder WithOverview(string overview);

    public ILabBuilder WithMaxPointsReward(uint maxPointsReward);

    public ILabBuilder WithCriterion(string criterion);

    public uint IncrementId();

    public AbsLab GetResult();
}
