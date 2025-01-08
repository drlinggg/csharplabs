using Repositories;

namespace DataBases;

public interface IDataBase
{
    public abstract TryAddResult Add<T>(T element);

    public abstract TryRemoveResult Remove<T>(T element);

    public abstract TryModifyResult Modify<T>(T element);

    public static abstract IDataBase GetInstance();
}
