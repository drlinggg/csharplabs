using DataBases;
using LearningResources.Labs;
using LearningResources.Lectures;
using Repositories;
using Services;
using Subjects;
using Users;
using Xunit;

namespace Test;

public class Tests
{
    [Fact]
    public void TestCreateSubjectWithIncorrectPoints()
    {
        AbsUser author = new User(1, "13245");
        AbsUser anotherUser = new User(2, "123454");
        IDataBase dataBase = DataBase.GetInstance();
        var entityCreatorService = new EntityCreatorService(dataBase);

        entityCreatorService.SubjectFactory.Name = "12345";
        entityCreatorService.SubjectFactory.Creator = author;
        TryCreateSubjectResult result = entityCreatorService.SubjectFactory.CreateSubject();

        Assert.Equal(result, new TryCreateSubjectResult.SummOfPointsIsntCorrect(30));
    }

    [Fact]
    public void TestCopiedEntityOriginIdEqualsOtherId()
    {
        AbsUser author = new User(1, "Alexey");
        AbsUser anotherAuthor = new User(12345, "Antony");
        IDataBase dataBase = DataBase.GetInstance();
        var entityCreatorService = new EntityCreatorService(dataBase);
        var entityChangerService = new EntityModifierService(dataBase);

        entityCreatorService.LabDir.Builder.WithName("OOPLab2").WithAuthor(author).WithOverview("some text here").WithCriterion("need more OOP!").WithMaxPointsReward(16);
        AbsLab originalLab = entityCreatorService.LabDir.Builder.GetResult();
        AbsLab copiedLab = originalLab.Clone(anotherAuthor, originalLab.Id + 1);

        Assert.Equal(copiedLab.OriginId, originalLab.Id);
    }

    [Fact]
    public void TestModifyByAnotherUser()
    {
        AbsUser author = new User(1, "Andy");
        AbsUser anotherUser = new User(456, "Andrey");
        IDataBase dataBase = DataBase.GetInstance();
        var dataBaseModifierService = new DataBaseService(dataBase);
        var entityCreatorService = new EntityCreatorService(dataBase);
        var entityChangerService = new EntityModifierService(dataBase);

        entityCreatorService.LectureDir.Builder.WithName("OOPLab2").WithAuthor(author).WithOverview("some text here").WithContent("123123123123123123");
        AbsLecture lecture = entityCreatorService.LectureDir.Builder.GetResult();
        dataBaseModifierService.Add(lecture);
        entityCreatorService.LectureDir.Builder.WithAuthor(anotherUser).WithOverview("newOverview").Id--;
        AbsLecture modifiedLecture = entityCreatorService.LectureDir.Builder.GetResult();
        TryModifyResult result = entityChangerService.Modify(modifiedLecture);

        Assert.Equal(result, new TryModifyResult.FailureModifierIsntAuthor(anotherUser));
    }
}
