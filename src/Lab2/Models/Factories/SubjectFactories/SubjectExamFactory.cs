using LearningResources.Labs;
using LearningResources.Lectures;
using Users;

namespace Subjects;

public class SubjectExamFactory : AbsSubjectFactory
{
    public SubjectExamFactory(
            uint id,
            string name,
            AbsUser creator,
            Dictionary<uint, AbsLecture> lectures,
            Dictionary<uint, AbsLab> labs) : base(
                                                id,
                                                name,
                                                creator,
                                                lectures,
                                                labs) { }

    public SubjectExamFactory() { }

    public override TryCreateSubjectResult CreateSubject()
    {
        // result is success if totalpoints = 100 and Failure otherwise
        uint totalPoints = Points;
        foreach (KeyValuePair<uint, AbsLab> lab in Labs)
        {
            totalPoints += lab.Value.MaxPointsReward;
        }

        if (totalPoints != 100)
            return new TryCreateSubjectResult.SummOfPointsIsntCorrect(totalPoints);

        var newSubject = new SubjectExam(
                                         this.Id,
                                         this.Name ?? throw new ArgumentNullException(),
                                         this.Creator ?? throw new ArgumentNullException(),
                                         this.Lectures ?? throw new ArgumentNullException(),
                                         this.Labs ?? throw new ArgumentNullException(),
                                         this.Points);
        return new TryCreateSubjectResult.Success(newSubject);
    }
}
