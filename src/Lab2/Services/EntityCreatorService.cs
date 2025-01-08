using DataBases;
using LearningResources.Labs;
using LearningResources.Lectures;
using Programs;
using Repositories;
using Subjects;
using Users;

namespace Services;

public class EntityCreatorService
{
    private readonly DataBaseService _dataBaseService;

    public LabDirector LabDir { get; set; }

    public LectureDirector LectureDir { get; set; }

    public ProgramDirector ProgramDir { get; set; }

    public AbsSubjectFactory SubjectFactory { get; set; }

    public EntityCreatorService(IDataBase dataBase)
    {
        // by default
        LabDir = new LabDirector(new LabBuilder());
        LectureDir = new LectureDirector(new LectureBuilder());
        ProgramDir = new ProgramDirector(new ProgramBuilder());
        SubjectFactory = new SubjectExamFactory();

        _dataBaseService = new DataBaseService(dataBase);
    }

    public TryAddResult AddProgram()
    {
        // creates version of program with current programdir configuraion
        TryAddResult addResult = _dataBaseService.Add(ProgramDir.Builder.GetResult());
        return addResult;
    }

    public TryAddResult AddLab()
    {
        // creates version of lab with current labdir configuraion
        TryAddResult addResult = _dataBaseService.Add(LabDir.Builder.GetResult());
        return addResult;
    }

    public TryAddResult AddLecture()
    {
        // creates version of lecture with current lecturedir configuration
        TryAddResult addResult = _dataBaseService.Add(LectureDir.Builder.GetResult());
        return addResult;
    }

    public TryAddResult AddSubject()
    {
        // creates version of subject with current subjectFactory configuration
        TryCreateSubjectResult createResult = SubjectFactory.CreateSubject();
        if (createResult is not TryCreateSubjectResult.Success)
            return new TryAddResult.FailureCouldntCreateBeforeAdding();

        TryAddResult addResult = _dataBaseService.Add(createResult);
        return addResult;
    }

    public TryAddResult AddOnCopy(AbsLecture entity)
    {
        // gets original entity, except of author and id what takes from configuration

        // getting our creator who copies entity
        AbsUser? curAuthor = LectureDir.Builder.User;
        if (curAuthor == null)
            return new TryAddResult.FailureCouldntCopyBeforeAdding();

        // giving new Id to copy and save originId in copy.OriginId
        TryAddResult addResult = _dataBaseService.Add(entity.Clone(curAuthor, LectureDir.Builder.IncrementId()));
        return addResult;
    }

    public TryAddResult AddOnCopy(AbsLab entity)
    {
        // gets original entity, except of author and id what takes from configuration

        // getting our creator who copies entity
        AbsUser? curAuthor = LabDir.Builder.User;
        if (curAuthor == null)
            return new TryAddResult.FailureCouldntCopyBeforeAdding();

        // giving new Id to copy and save originId in copy.OriginId
        TryAddResult addResult = _dataBaseService.Add(entity.Clone(curAuthor, LabDir.Builder.IncrementId()));
        return addResult;
    }

    public TryAddResult AddOnCopy(AbsSubject entity)
    {
        // gets original entity, except of author and id what takes from configuration

        // getting our creator who copies entity
        AbsUser? curAuthor = LabDir.Builder.User;
        if (curAuthor == null)
            return new TryAddResult.FailureCouldntCopyBeforeAdding();

        // giving new Id to copy and save originId in copy.OriginId
        TryAddResult addResult = _dataBaseService.Add(entity.Clone(curAuthor, SubjectFactory.Id++));
        return addResult;
     }
}
