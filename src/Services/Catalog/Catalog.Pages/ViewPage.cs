using Catalog.Domain;
using Catalog.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using Sooduskorv_MVC.Facade;
using System.Threading.Tasks;

namespace Catalog.Pages
{
    public abstract class ViewPage<TRepository, TDomain, TView, TData> :
        TitledPage<TRepository, TDomain, TView, TData>
        where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
        where TDomain : IEntity<TData>
        where TData : UniqueEntityData, new()
        where TView : UniqueEntityView
    {

        protected ViewPage(TRepository r, string title) : base(r, title) { }

        public async Task OnGetIndexAsync(string sortOrder,
            string id, string currentFilter, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue)
        {
            SelectedId = id;
            await getList(sortOrder, currentFilter, searchString, pageIndex,
                fixedFilter, fixedValue).ConfigureAwait(true);

        }

        public virtual IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
            SortOrder = sortOrder;
            SearchString = searchString;
            PageIndex = pageIndex ?? 0;

            return Page();
        }

        public async Task<IActionResult> OnPostCreateAsync(
            string sortOrder,
            string searchString,
            int? pageIndex,
            string fixedFilter,
            string fixedValue)
        {
            if (!await addObject(sortOrder, searchString, pageIndex, fixedFilter, fixedValue)
                .ConfigureAwait(true)) return Page();

            return Redirect(IndexUrl.ToString());
        }


        public async Task<IActionResult> OnGetDeleteAsync(
            string id,
            string sortOrder,
            string searchString,
            int? pageIndex,
            string fixedFilter,
            string fixedValue)
        {
            await getObject(id, sortOrder, searchString, pageIndex, fixedFilter, fixedValue).ConfigureAwait(true);

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(string id, string sortOrder, string searchString,
            int pageIndex,
            string fixedFilter, string fixedValue)
        {
            await deleteObject(id, sortOrder, searchString, pageIndex, fixedFilter, fixedValue).ConfigureAwait(true);

            return Redirect(IndexUrl.ToString());
        }

        public virtual async Task<IActionResult> OnGetDetailsAsync(string id, string sortOrder, string searchString,
            int pageIndex,
            string fixedFilter, string fixedValue)
        {
            await getObject(id, sortOrder, searchString, pageIndex, fixedFilter, fixedValue).ConfigureAwait(true);

            return Page();
        }

        public async Task<IActionResult> OnGetEditAsync(
            string id,
            string sortOrder,
            string searchString,
            int pageIndex,
            string fixedFilter,
            string fixedValue)
        {
            await getObject(id, sortOrder, searchString, pageIndex, fixedFilter, fixedValue).ConfigureAwait(true);

            return Page();
        }

        public async Task<IActionResult> OnPostEditAsync(string sortOrder, string searchString, int pageIndex,
            string fixedFilter, string fixedValue)
        {
            await updateObject(sortOrder, searchString, pageIndex, fixedFilter, fixedValue).ConfigureAwait(true);

            return Redirect(IndexUrl.ToString());
        }


    }
}
