using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Domain.Common;

namespace Web.Pages.Common
{
    public abstract class BasePage<TRepository, TDomain, TView, TData> :
        PageModel
        where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
    {
        protected TRepository db { get; }
        protected internal BasePage(TRepository r) => db = r;
        public string SortOrder
        {
            get => db.SortOrder;
            set => db.SortOrder = value;
        }
        public string SearchString
        {
            get => db.SearchString;
            set => db.SearchString = value;
        }
        public string CurrentFilter
        {
            get => db.CurrentFilter;
            set => db.CurrentFilter = value;
        }
        public string FixedValue
        {
            get => db.FixedValue;
            set => db.FixedValue = value;
        }

        public bool HasFixedFilter => !string.IsNullOrWhiteSpace(FixedFilter);

        public string FixedFilter
        {
            get => db.FixedFilter;
            set => db.FixedFilter = value;
        }

        protected internal void setFixedFilter(string fixedFilter, string fixedValue)
        {
            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
        }

        protected internal abstract void setPageValues(string sortOrder, string searchString, in int? pageIndex);

        internal static string
            getCurrentFilter(string currentFilter, string searchString, ref int? pageIndex)
        {
            if (searchString != currentFilter) { pageIndex = 1; }

            return searchString;

        }
    }
}