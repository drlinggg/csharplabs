using Users;

namespace LearningResources.Lectures;

public class Lecture : AbsLecture
{
    public override Lecture Clone()
    {
        return new Lecture(this);
    }

    public override Lecture Clone(AbsUser author, uint newId)
    {
        var copied = new Lecture(this);
        copied.Author = author;
        copied.Id = newId;
        copied.OriginId = Id;
        return copied;
    }

    public Lecture(
            uint id,
            string name,
            AbsUser author,
            string overview,
            string content) : base(id, name, author, overview, content) { }

    private Lecture(Lecture other) : base(other) { }
}
