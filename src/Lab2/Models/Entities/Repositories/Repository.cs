using Identifiable;

namespace Repositories;

public class Repository<T> where T : IIdentifiable
{
    private readonly Dictionary<uint, T> elements = new Dictionary<uint, T>();

    public TryAddResult Add(T element)
    {
        if (ContainsKey(element.Id))
            return new TryAddResult.FailureAlreadyContainsID(element.Id);

        elements.Add(element.Id, element);
        return new TryAddResult.Success();
    }

    public TryRemoveResult Remove(T element)
    {
        if (!ContainsKey(element.Id))
            return new TryRemoveResult.FailureNoSuchID(element.Id);

        elements.Remove(element.Id);
        return new TryRemoveResult.Success();
    }

    public bool ContainsKey(uint id)
    {
        return elements.ContainsKey(id);
    }

    public T GetById(uint id)
    {
        return elements[id];
    }
}
