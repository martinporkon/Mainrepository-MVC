using Catalog.Domain;

namespace Catalog.Pages
{
    public abstract class CrudPage<TRepository, TDomain, TData> : BasePage<TRepository, TDomain, TData>
        where TRepository : ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
    {
        protected CrudPage(TRepository r) : base(r)
        {

        }
    }
}