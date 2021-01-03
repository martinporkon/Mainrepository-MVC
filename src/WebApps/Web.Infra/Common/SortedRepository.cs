using System;
using System.Net.Http;
using System.Threading;
using Web.Domain.Common;
using Web.Domain.DTO.Common;

namespace Web.Infra.Common
{
    public abstract class SortedRepository<TDomain, TData> : BaseRepository<TDomain, TData>, ISorting
        where TDomain : IDto<TData>
        where TData : PeriodEntityDto, new()
    {
        public string SortOrder { get; set; }
        public string DescendingString => "_desc";

        protected SortedRepository(IHttpClientFactory h, string baseAddress, HttpMethod m,
            CancellationToken t) : base(h, baseAddress, m, t) { }

        protected internal override HttpClient getValuesFrom()
        {
            var request = base.getValuesFrom();
            request = addBaseAddress(request);

            return request;
        }

        private HttpClient addBaseAddress(HttpClient request)
        {
            if (string.IsNullOrWhiteSpace(BaseAddress)) throw new HttpRequestException();
            request.BaseAddress = new Uri(BaseAddress);
            return request;
        }

        // TODO apply the sortOrder to the query

    }
}