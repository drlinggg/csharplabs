using Importances;

namespace Messages;

public class Message : IMessage
{
    public Guid Id { get; init; }

    public string Header { get; init; }

    public string Body { get; init; }

    public ImportanceLevel LevelOfImportance { get; init; }

    public IMessage Clone()
    {
        return new Message(this);
    }

    public Message(string header, string body, ImportanceLevel levelOfImportance)
    {
        this.Header = header;
        this.Body = body;
        this.LevelOfImportance = levelOfImportance;
        Id = Guid.NewGuid();
    }

    private Message(Message other) : this(other.Header, other.Body, other.LevelOfImportance) { }
}
