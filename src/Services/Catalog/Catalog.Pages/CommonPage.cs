using Catalog.Domain;

namespace Catalog.Pages
{
    public abstract class CommonPage<TRepository, TDomain, TData> : PaginatedPage<TRepository, TDomain, TData>
        where TRepository : ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
    {
        protected CommonPage(TRepository r) : base(r)
        {

        }
    }
}