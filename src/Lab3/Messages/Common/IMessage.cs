using Importances;

namespace Messages;

public interface IMessage
{
    public Guid Id { get; init; }

    public string Header { get; init; }

    public string Body { get; init; }

    public ImportanceLevel LevelOfImportance { get; init; }

    public abstract IMessage Clone();
}
