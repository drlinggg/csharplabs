using Users;

namespace LearningResources.Lectures;

public class LectureBuilder : ILectureBuilder
{
    public AbsUser? User { get; private set; }

    // all Id are in [1;4 294 967 295]
    public uint Id { get; set; } = 1;

    private string? name;

    private string? overview;

    private string? content;

    public ILectureBuilder WithName(string name)
    {
        this.name = name;
        return this;
    }

    public ILectureBuilder WithAuthor(AbsUser user)
    {
        this.User = user;
        return this;
    }

    public ILectureBuilder WithOverview(string overview)
    {
        this.overview = overview;
        return this;
    }

    public ILectureBuilder WithContent(string content)
    {
        this.content = content;
        return this;
    }

    public uint IncrementId()
    {
        return this.Id++;
    }

    public AbsLecture GetResult()
    {
        return new Lecture(
                Id++,
                name ?? throw new ArgumentNullException(),
                User ?? throw new ArgumentNullException(),
                overview ?? throw new ArgumentNullException(),
                content ?? throw new ArgumentNullException());
    }

    public ILectureBuilder Clone()
    {
        return new LectureBuilder(this);
    }

    public LectureBuilder() { }

    private LectureBuilder(LectureBuilder other)
    {
        this.Id = other.Id;
        this.name = other.name;
        this.User = other.User;
        this.overview = other.overview;
        this.content = other.content;
    }
}
