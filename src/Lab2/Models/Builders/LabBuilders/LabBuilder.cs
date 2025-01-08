using Users;

namespace LearningResources.Labs;

public class LabBuilder : ILabBuilder
{
    public AbsUser? User { get; private set; }

    // all Id are in [1;4 294 967 295]
    public uint Id { get; set; } = 1;

    private string? name;

    private string? overview;

    private string? criterion;

    private uint maxPointsReward;

    public ILabBuilder WithName(string name)
    {
        this.name = name;
        return this;
    }

    public ILabBuilder WithAuthor(AbsUser user)
    {
        this.User = user;
        return this;
    }

    public ILabBuilder WithOverview(string overview)
    {
        this.overview = overview;
        return this;
    }

    public ILabBuilder WithMaxPointsReward(uint maxPointsReward)
    {
        this.maxPointsReward = maxPointsReward;
        return this;
    }

    public ILabBuilder WithCriterion(string criterion)
    {
        this.criterion = criterion;
        return this;
    }

    public uint IncrementId()
    {
        return this.Id++;
    }

    public AbsLab GetResult()
    {
        return new Lab(
                Id++,
                name ?? throw new ArgumentNullException(),
                User ?? throw new ArgumentNullException(),
                overview ?? throw new ArgumentNullException(),
                criterion ?? throw new ArgumentNullException(),
                maxPointsReward);
    }

    public ILabBuilder Clone()
    {
        return new LabBuilder(this);
    }

    public LabBuilder() { }

    private LabBuilder(LabBuilder other)
    {
        this.Id = other.Id;
        this.name = other.name;
        this.User = other.User;
        this.overview = other.overview;
        this.criterion = other.criterion;
        this.maxPointsReward = other.maxPointsReward;
    }
}
