namespace Catalog.Domain
{
    public interface IRepository<T> : ICrudMethods<T>, ISorting, IFiltering, IPaging, IRepository
    {

    }

    public interface IRepository
    {
        object GetById(string id);
    }
}