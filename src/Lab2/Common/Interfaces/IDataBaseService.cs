using Repositories;

namespace Services;

public interface IDataBaseService
{
    public abstract TryAddResult Add<T>(T item);

    public abstract TryRemoveResult Remove<T>(T item);

    public abstract TryModifyResult Modify<T>(T element);
}
