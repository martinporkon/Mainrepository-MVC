using Catalog.Domain;
using Microsoft.AspNetCore.Mvc;
using Sooduskorv_MVC.Facade;
using System.Threading.Tasks;

namespace Catalog.Pages
{
    public abstract class CrudPage<TRepository, TDomain, TView, TData> :
            BasePage<TRepository, TDomain, TView, TData>
            where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
            where TView : UniqueEntityView
    {

        protected CrudPage(TRepository r) : base(r) { }

        [BindProperty]
        public TView Item { get; set; }
        public string ItemId => Item?.GetId() ?? string.Empty;

        protected internal async Task<bool> addObject(string fixedFilter, string fixedValue)
        {
            setFixedFilter(fixedFilter, fixedValue);
            if (!ModelState.IsValid) return false;
            await db.Add(toObject(Item)).ConfigureAwait(true);
            return true;
        }
        protected internal async Task<bool> addObject(string sortOrder, string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            setPageValues(sortOrder, searchString, pageIndex);
            return await addObject(fixedFilter, fixedValue).ConfigureAwait(true);
        }

        protected internal async Task<bool> updateObject(string fixedFilter, string fixedValue)
        {
            setFixedFilter(fixedFilter, fixedValue);

            if (!ModelState.IsValid) return false;
            await db.Update(toObject(Item)).ConfigureAwait(true);

            return true;
        }

        protected internal async Task<bool> updateObject(string sortOrder, string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            setPageValues(sortOrder, searchString, pageIndex);
            return await updateObject(fixedFilter, fixedValue).ConfigureAwait(true);
        }

        protected internal async Task getObject(string id, string fixedFilter, string fixedValue)
        {
            setFixedFilter(fixedFilter, fixedValue);
            var o = await db.Get(id).ConfigureAwait(true);
            Item = toView(o);
        }

        protected internal async Task getObject(string id, string sortOrder, string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            setPageValues(sortOrder, searchString, pageIndex);
            await getObject(id, fixedFilter, fixedValue).ConfigureAwait(true);
        }

        protected internal async Task deleteObject(string id, string fixedFilter, string fixedValue)
        {
            setFixedFilter(fixedFilter, fixedValue);
            await db.Delete(id).ConfigureAwait(true);
        }

        protected internal async Task deleteObject(string id, string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue)
        {
            setPageValues(sortOrder, searchString, pageIndex);
            await deleteObject(id, fixedFilter, fixedValue).ConfigureAwait(true);
        }

        protected abstract TDomain toObject(TView v);

        protected abstract TView toView(TDomain o);

    }
}