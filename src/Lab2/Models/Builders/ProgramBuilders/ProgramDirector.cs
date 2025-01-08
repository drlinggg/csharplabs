namespace Programs;

public class ProgramDirector
{
    public IProgramBuilder Builder { get; private set; }

    public ProgramDirector(IProgramBuilder builder)
    {
        this.Builder = builder;
    }

    public void ChangeBuilder(IProgramBuilder builder)
    {
        uint savedNextId = this.Builder.Id;
        this.Builder = builder;
        this.Builder.Id = savedNextId;
    }
}
