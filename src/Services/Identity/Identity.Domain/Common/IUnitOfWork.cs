using System.Threading.Tasks;

namespace Identity.Domain.Common
{
    public interface IUnitOfWork<T>
    {
        Task<T> registerDeleted(T entity);
        Task<T> registerDirty(T entity);
        Task<T> registerClean(T entity);
        Task<T> registerNew(T entity);
        Task<T> commit();
    }
}