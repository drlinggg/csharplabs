using DataBases;
using Repositories;

namespace Services;

public class DataBaseService : IDataBaseService
{
    private readonly IDataBase _dataBase;

    public DataBaseService(IDataBase dataBase)
    {
        _dataBase = dataBase;
    }

    public TryAddResult Add<T>(T item)
    {
        return _dataBase.Add(item);
    }

    public TryRemoveResult Remove<T>(T item)
    {
        return _dataBase.Remove(item);
    }

    public TryModifyResult Modify<T>(T element)
    {
        return _dataBase.Modify(element);
    }
}
