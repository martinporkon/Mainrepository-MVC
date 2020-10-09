using Catalog.Domain;

namespace Catalog.Pages
{
    public abstract class PaginatedPage<TRepository, TDomain, TData> : CrudPage<TRepository, TDomain, TData>
        where TRepository : ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
    {
        protected PaginatedPage(TRepository r) : base(r)
        {

        }
    }
}