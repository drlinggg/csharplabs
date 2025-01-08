using Assessments;
using LearningResources.Labs;
using LearningResources.Lectures;
using Users;

namespace Subjects;

public class SubjectExam : AbsSubject
{
    public override AbsAssessment CreateAssesment(uint points)
    {
        return new Exam(points);
    }

    public SubjectExam(
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

    public override SubjectExam Clone()
    {
        // full copy
        return new SubjectExam(this);
    }

    public override SubjectExam Clone(AbsUser author, uint newId)
    {
        // copy except of author and ids
        var copied = new SubjectExam(this);
        copied.Author = author;
        copied.Id = newId;
        copied.OriginId = Id;
        return copied;
    }

    private SubjectExam(SubjectExam other) : base(
                                                  other.Id,
                                                  other.Name,
                                                  other.Author,
                                                  other.Lectures,
                                                  other.Labs) { }
}
