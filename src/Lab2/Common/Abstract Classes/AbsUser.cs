namespace Users;

public abstract class AbsUser
{
    public uint Id { get; init; }

    public string Name { get; init; }

    protected AbsUser(uint id, string name)
    {
        this.Id = id;
        this.Name = name;
    }
}
