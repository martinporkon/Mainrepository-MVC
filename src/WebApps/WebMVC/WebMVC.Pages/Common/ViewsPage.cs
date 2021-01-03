using SooduskorvWebMVC.Domain.DTO.Common;
using WebMVC.Domain.Common;
using WebMVC.Facade.Profiles.Common;

namespace Basket.Pages.Common
{
    public abstract class ViewsPage<TRepository, TDomain, TView, TData> :
        ViewPage<TRepository, TDomain, TView, TData>
        where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
        where TDomain : IDto<TData>
        where TData : UniqueDto, new()
        where TView : UniqueView
    {


    }
}