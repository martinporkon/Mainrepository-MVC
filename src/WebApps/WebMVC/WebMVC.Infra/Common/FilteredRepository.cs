using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using Web.Domain.Common;
using Web.Domain.DTO.Common;

namespace Web.Infra.Common
{
    public abstract class FilteredRepository<TDomain, TData> : SortedRepository<TDomain, TData>, IFiltering
        where TDomain : IDto<TData>
        where TData : PeriodEntityDto, new()
    {
        public string SearchString { get; set; }
        public string CurrentFilter { get; set; }
        public string FixedFilter { get; set; }
        public string FixedValue { get; set; }

        protected FilteredRepository(IHttpClientFactory h, string baseAddress, HttpMethod m,
            CancellationToken t) : base(h, baseAddress, m) { }

        protected internal override HttpClient getValuesFrom()
        {
            var response = base.getValuesFrom();
        }

        // TODO add the string features to the query request


    }
}