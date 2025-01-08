using Assessments;
using LearningResources.Labs;
using LearningResources.Lectures;
using Users;

namespace Subjects;

public class SubjectTest : AbsSubject
{
    public override AbsAssessment CreateAssesment(uint points)
    {
        return new Test(points);
    }

    public SubjectTest(
            uint id,
            string name,
            AbsUser author,
            Dictionary<uint, AbsLecture> lectures,
            Dictionary<uint, AbsLab> labs,
            uint points) : base(
                               id,
                               name,
                               author,
                               lectures,
                               labs)
    {
        this.Assessment = CreateAssesment(points);
    }

    public override SubjectTest Clone()
    {
        // full copy
        return new SubjectTest(this);
    }

    public override SubjectTest Clone(AbsUser author, uint newId)
    {
        // copy except of author and ids
        var copied = new SubjectTest(this);
        copied.Author = author;
        copied.Id = newId;
        copied.OriginId = Id;
        return copied;
    }

    private SubjectTest(SubjectTest other) : base(
                                                  other.Id,
                                                  other.Name,
                                                  other.Author,
                                                  other.Lectures,
                                                  other.Labs) { }
}
