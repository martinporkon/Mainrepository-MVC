using Microsoft.AspNetCore.Mvc.Rendering;
using Sooduskorv_MVC.Aids.Constants;
using Sooduskorv_MVC.Data.CommonData;
using System;
using System.Collections.Generic;
using Web.Domain.Common;
using Web.Facade.Common;

namespace Web.Pages.Common
{
    public abstract class TitledPage<TRepository, TDomain, TView, TData> :
       PagedPage<TRepository, TDomain, TView, TData>
       where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
       where TData : UniqueEntityData, new()
       where TView : PeriodView
    {

        protected internal TitledPage(TRepository r, string title) : base(r) => PageTitle = title;

        public string PageTitle { get; }

        public string PageSubTitle => FixedValue is null
        ? string.Empty
        : $"{pageSubtitle()}";

        protected virtual string pageSubtitle() => string.Empty;

        public Uri PageUrl => pageUrl();
        public Uri CreateUrl => createUrl();

        protected internal Uri createUrl()
            => new Uri($"{PageUrl}/Create" +
                       "?handler=Create" +
                       $"&pageIndex={PageIndex}" +
                       $"&sortOrder={SortOrder}" +
                       $"&searchString={SearchString}" +
                       $"&fixedFilter={FixedFilter}" +
                       $"&fixedValue={FixedValue}", UriKind.Relative);

        protected abstract Uri pageUrl();

        public Uri IndexUrl => indexUrl();

        protected internal Uri indexUrl() =>
            new Uri($"{PageUrl}/Index?handler=Index&fixedFilter={FixedFilter}&fixedValue={FixedValue}", UriKind.Relative);

        protected internal static string itemName(IEnumerable<SelectListItem> list, string id)
        {
            if (list is null) return Word.Unspecified;

            foreach (var m in list)
                if (m.Value == id)
                    return m.Text;

            return Word.Unspecified;
        }


        public virtual bool IsMasterDetail() => PageSubTitle != string.Empty;

    }
}
