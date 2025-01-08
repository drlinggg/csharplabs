using LearningResources.Labs;
using LearningResources.Lectures;
using Users;

namespace Subjects;

public class SubjectTestFactory : AbsSubjectFactory
{
    public SubjectTestFactory(
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

    public SubjectTestFactory() { }

    public override TryCreateSubjectResult CreateSubject()
    {
        uint totalPoints = 0;
        foreach (KeyValuePair<uint, AbsLab> lab in Labs)
        {
            totalPoints += lab.Value.MaxPointsReward;
        }

        if (totalPoints != 100)
            return new TryCreateSubjectResult.SummOfPointsIsntCorrect(totalPoints);
        var newSubject = new SubjectTest(
                                         this.Id,
                                         this.Name ?? throw new ArgumentNullException(),
                                         this.Creator ?? throw new ArgumentNullException(),
                                         this.Lectures ?? throw new ArgumentNullException(),
                                         this.Labs ?? throw new ArgumentNullException(),
                                         this.Points);
        return new TryCreateSubjectResult.Success(newSubject);
    }
}
