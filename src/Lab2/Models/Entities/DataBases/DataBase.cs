using LearningResources.Labs;
using LearningResources.Lectures;
using Programs;
using Repositories;
using Subjects;

namespace DataBases;

public class DataBase : IDataBase
{
    private static DataBase? instance;

    private readonly Repository<AbsProgram> programs = new Repository<AbsProgram>();

    private readonly Repository<AbsSubject> subjects = new Repository<AbsSubject>();

    private readonly Repository<AbsLecture> lectures = new Repository<AbsLecture>();

    private readonly Repository<AbsLab> labs = new Repository<AbsLab>();

    public TryAddResult Add<T>(T element)
    {
        // find type of element and add it in repo<type>
        return element switch
        {
            AbsProgram el => programs.Add(el),
            AbsSubject el => subjects.Add(el),
            AbsLecture el => lectures.Add(el),
            AbsLab el => labs.Add(el),
            _ => throw new ArgumentException("Invalid type"),
        };
    }

    public TryRemoveResult Remove<T>(T element)
    {
        // find type of element and remove it in repo<type>
        return element switch
        {
            AbsProgram el => programs.Remove(el),
            AbsSubject el => subjects.Remove(el),
            AbsLecture el => lectures.Remove(el),
            AbsLab el => labs.Remove(el),
            _ => throw new ArgumentException("Invalid type"),
        };
    }

    public TryModifyResult Modify<T>(T element)
    {
        // if repo contains entity with the same id and author, remove old version and add new version
        // if repo doesnt contain entity with such id, return Result.FailureNoEntityWithSameId(added entity id)
        // if repo doesn contain the same user in entity with such id, return Result.FailureModifierIsntAuthor(origin author)
        if (element is not AbsLab &&
                element is not AbsSubject &&
                element is not AbsLecture)
        {
            throw new ArgumentException("Invalid type");
        }

        if (element is AbsSubject el)
        {
            if (!subjects.ContainsKey(el.Id))
                return new TryModifyResult.FailureNoEntityWithSameId(el.Id);

            if (subjects.GetById(el.Id).Author != el.Author)
                return new TryModifyResult.FailureModifierIsntAuthor(el.Author);

            if (subjects.GetById(el.Id).Labs != el.Labs)
                return new TryModifyResult.FailureHasDifferentLabs();

            Remove(el);
            Add(el);
            return new TryModifyResult.Success();
        }

        if (element is AbsLecture el1)
        {
            if (!lectures.ContainsKey(el1.Id))
                return new TryModifyResult.FailureNoEntityWithSameId(el1.Id);

            if (lectures.GetById(el1.Id).Author != el1.Author)
                return new TryModifyResult.FailureModifierIsntAuthor(el1.Author);

            Remove(el1);
            Add(el1);
            return new TryModifyResult.Success();
        }

        if (element is AbsLab el2)
        {
            if (!labs.ContainsKey(el2.Id))
                return new TryModifyResult.FailureNoEntityWithSameId(el2.Id);

            if (labs.GetById(el2.Id).Author != el2.Author)
                return new TryModifyResult.FailureModifierIsntAuthor(el2.Author);

            Remove(el2);
            Add(el2);
            return new TryModifyResult.Success();
        }

        return new TryModifyResult.UknownFailure();
   }

    private DataBase() { }

    public static IDataBase GetInstance()
    {
        if (instance == null)
            instance = new DataBase();
        return instance;
    }
}
