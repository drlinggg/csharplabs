using Users;

namespace LearningResources.Lectures;

public interface ILectureBuilder
{
    public AbsUser? User { get; }

    public uint Id { get; set; }

    public ILectureBuilder WithName(string name);

    public ILectureBuilder WithAuthor(AbsUser user);

    public ILectureBuilder WithOverview(string overview);

    public ILectureBuilder WithContent(string content);

    public uint IncrementId();

    public AbsLecture GetResult();
}
