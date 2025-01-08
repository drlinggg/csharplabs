using Users;

namespace LearningResources.Labs;

public class Lab : AbsLab
{
    public override Lab Clone()
    {
        // full copy
        return new Lab(this);
    }

    public override Lab Clone(AbsUser author, uint newId)
    {
        // copy except of author and ids
        var copied = new Lab(this);
        copied.Author = author;
        copied.Id = newId;
        copied.OriginId = Id;
        return copied;
    }

    public Lab(
            uint id,
            string name,
            AbsUser author,
            string overview,
            string criterion,
            uint maxPointsReward) : base(
                                        id,
                                        name,
                                        author,
                                        overview,
                                        criterion,
                                        maxPointsReward) { }

    private Lab(Lab other) : base(other) { }
}
