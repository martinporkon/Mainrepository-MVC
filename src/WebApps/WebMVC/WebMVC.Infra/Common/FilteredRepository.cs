using System.Net.Http;
using Web.Domain.Common;
using Web.Domain.DTO.Common;

namespace Web.Infra.Common
{
    public class FilteredRepository<TDomain, TData> : SortedRepository<TDomain, TData>, IFiltering
        where TDomain : IDto<TData>
        where TData : PeriodEntityDto, new()
    {
        public string SearchString { get; set; }
        public string CurrentFilter { get; set; }
        public string FixedFilter { get; set; }
        public string FixedValue { get; set; }

        public FilteredRepository(IHttpClientFactory h, string baseAddress) : base(h, baseAddress) { }




    }
}