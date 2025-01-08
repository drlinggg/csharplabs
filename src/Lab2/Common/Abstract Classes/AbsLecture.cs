using Prototype;
using Users;

namespace LearningResources.Lectures;

public abstract class AbsLecture : AbsLearningResource, IPrototype<AbsLecture>
{
    public abstract AbsLecture Clone(AbsUser author, uint newId);

    public abstract AbsLecture Clone();

    protected string Content { get; set; }

    protected AbsLecture(AbsLecture other) : base(
                                                other.Id,
                                                other.Name,
                                                other.Author,
                                                other.Overview)
    {
        this.Content = other.Content;
    }

    protected AbsLecture(
            uint id,
            string name,
            AbsUser author,
            string overview,
            string content) : base(id, name, author, overview)
    {
        this.Content = content ?? throw new ArgumentNullException(nameof(content));
    }
}
