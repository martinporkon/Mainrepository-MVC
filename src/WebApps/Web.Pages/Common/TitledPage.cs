using System;

namespace Web.Pages.Common
{
    public abstract class TitledPage<TRepository, TDomain, TView, TData> :
        PagedPage<TRepository, TDomain, TView, TData>
        where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
        where TView : PeriodView
    {
        protected internal TitledPage(TRepository r, string title) : base(r)
            => PageTitle = title;

        public string PageTitle { get; }

        public string PageSubTitle => FixedValue is null
            ? string.Empty
            : $"{pageSubtitle()}";

        public Uri IndexUrl => indexUrl();
        public Uri PageUrl => pageUrl();
        public Uri CreateUrl => createUrl();

        protected internal virtual string pageSubtitle() => string.Empty;
        protected internal abstract Uri pageUrl();

        // TODO fix
        protected internal Uri indexUrl() =>
            new Uri($"{PageUrl}/Index" +
            $"?handler=Index&fixedFilter={FixedFilter}" +
            $"&fixedValue={FixedValue}", UriKind.Relative);

        protected internal Uri createUrl()
            => new Uri($"{PageUrl}/Create" +
                       "?handler=Create" +
                       $"&pageIndex={PageIndex}" +
                       $"&sortOrder={SortOrder}" +
                       $"&searchString={SearchString}" +
                       $"&fixedFilter={FixedFilter}" +
                       $"&fixedValue={FixedValue}", UriKind.Relative);

    }
}