namespace LearningResources.Labs;

public class LabDirector
{
    public ILabBuilder Builder { get; private set; }

    public LabDirector(ILabBuilder builder)
    {
        this.Builder = builder;
    }

    public void ChangeBuilder(ILabBuilder builder)
    {
        uint savedNextId = this.Builder.Id;
        this.Builder = builder;
        this.Builder.Id = savedNextId;
    }
}
