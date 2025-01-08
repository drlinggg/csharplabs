namespace LearningResources.Lectures;

public class LectureDirector
{
    public ILectureBuilder Builder { get; private set; }

    public LectureDirector(ILectureBuilder builder)
    {
        this.Builder = builder;
    }

    public void ChangeBuilder(ILectureBuilder builder)
    {
        uint savedNextId = this.Builder.Id;
        this.Builder = builder;
        this.Builder.Id = savedNextId;
    }
}
