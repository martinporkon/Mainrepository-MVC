using System;
using System.Collections.Generic;
using System.Linq;
using Aids.Constants;
using CommonData;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quantity.Domain.Common;
using Quantity.Facade.Common;
using Quantity.Pages.Common;

namespace Quantity.Pages.Common {

    public abstract class TitledPage<TRepository, TDomain, TView, TData> :
        PagedPage<TRepository, TDomain, TView, TData>
        where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
        where TView : PeriodView {

        protected internal TitledPage(TRepository r, string title) : base(r) => PageTitle = title;

        public string PageTitle { get;}

        public string PageSubTitle => FixedValue is null
        ? string.Empty
        : $"{pageSubtitle()}";

        public virtual string pageSubtitle() => string.Empty;

        public Uri PageUrl => pageUrl();
        public Uri CreateUrl => createUrl();

        public Uri createUrl() 
            => new Uri($"{PageUrl}/Create"+
                       "?handler=Create"+
                       $"&pageIndex={PageIndex}" +
                       $"&sortOrder={SortOrder}" +
                       $"&searchString={SearchString}" +
                       $"&fixedFilter={FixedFilter}"+
                       $"&fixedValue={FixedValue}", UriKind.Relative);

        public abstract Uri pageUrl();

        public Uri IndexUrl => indexUrl();

        public Uri indexUrl() =>
            new Uri($"{PageUrl}/Index?handler=Index&fixedFilter={FixedFilter}&fixedValue={FixedValue}", UriKind.Relative);

        protected internal static IEnumerable<SelectListItem> newItemsList<TTDomain, TTData>(IRepository<TTDomain> r,
            Func<TTDomain, bool> condition = null)
            where TTDomain : IEntity<TTData>
            where TTData : NamedEntityData, new() {
            var items = r?.Get().GetAwaiter().GetResult();
            var l = items is null 
                ? new List<SelectListItem>() 
                : condition is null? 
                    items
                    .Select(m => new SelectListItem(m.Data.Name, m.Data.Id))
                    .ToList(): 
                    items
                    .Where(condition )
                    .Select(m => new SelectListItem(m.Data.Name, m.Data.Id))
                    .ToList();
            l.Insert(0, new SelectListItem(Word.UnSpecified, null));
            return l;
        }

        protected internal static string itemName(IEnumerable<SelectListItem> list, string id) {
            if (list is null) return Word.UnSpecified;

            foreach (var m in list)
                if (m.Value == id)
                    return m.Text;

            return Word.UnSpecified;
        }

        public virtual bool IsMasterDetail() => PageSubTitle != string.Empty;

    }

}
