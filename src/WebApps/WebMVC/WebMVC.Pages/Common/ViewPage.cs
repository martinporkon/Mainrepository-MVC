using WebMVC.Domain.Common;

namespace Basket.Pages.Common
{
    public abstract class ViewPage<TRepository, TDomain, TView, TData> :
        TitledPage<TRepository, TDomain, TView, TData>
        where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
    {
        
    }
}