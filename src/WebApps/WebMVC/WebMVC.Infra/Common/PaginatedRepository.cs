using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using Sooduskorv_MVC.Data.CommonData;
using Web.Domain.Common;

namespace Web.Infra.Common
{
    public abstract class PaginatedRepository<TDomain, TData> : FilteredRepository<TDomain, TData>, IPaging
        where TDomain : IEntity<TData>
        where TData : PeriodData, new()
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => getTotalPages(PageSize);
        public bool HasNextPage => PageIndex < TotalPages;
        public bool HasPreviousPage => PageIndex > 1;

        protected PaginatedRepository(HttpClient h, string baseAddress, HttpMethod m,
            CancellationToken t) : base(h, baseAddress, m, t) { }

        internal int getTotalPages(in int pageSize)
        {
            /*var count = getItemsCount();
            var pages = countTotalPages(count, pageSize);*/
            // TODO
            return pageSize;
        }

        // TODO add the pagination features to the request

        protected internal override HttpClient getValuesFrom() => addSkipAndTake(base.getValuesFrom());

        private HttpClient addSkipAndTake(HttpClient request)
        {
            var foo
                = request.DefaultRequestHeaders;
            foo.Clear();
            foo.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            foo.AcceptEncoding.Add(new StringWithQualityHeaderValue("brotli"));
            return request;
        }

        private HttpClient addFilters(HttpClient h)
        {
            if (!string.IsNullOrEmpty(PageIndex.ToString())) throw new Exception();
            if (!string.IsNullOrEmpty(PageSize.ToString())) throw new Exception();
            if (!string.IsNullOrEmpty(TotalPages.ToString())) throw new Exception();
            if (!string.IsNullOrEmpty(HasNextPage.ToString())) throw new Exception();
            if (!string.IsNullOrEmpty(HasPreviousPage.ToString())) throw new Exception();

            // TODO add the filters to the request uri of the request
            h.BaseAddress = new Uri("/aa");
            // TODO new HttpRequestMessage better.

            return h;


        }


    }
}