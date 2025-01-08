using DataBases;
using Repositories;

namespace Services;

public class EntityModifierService
{
    private readonly DataBaseService _dataBaseService;

    public EntityModifierService(IDataBase dataBase)
    {
       _dataBaseService = new DataBaseService(dataBase);
    }

    public TryModifyResult Modify<T>(T element)
    {
        return _dataBaseService.Modify(element);
    }
}
