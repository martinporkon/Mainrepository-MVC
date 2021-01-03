using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Common
{
    public abstract class ViewsPage<TPage, TRepository, TDomain, TView, TData> :
        ViewPage<TPage, TRepository, TDomain, TView, TData>
        where TPage : PageModel
        where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
        where TDomain : IDto<TData>
        where TData : PeriodEntityDto, new()
        where TView : PeriodView// TODO fix this T
    {
        protected ViewsPage(TRepository r, string title) : base(r, title) { }
    }
}