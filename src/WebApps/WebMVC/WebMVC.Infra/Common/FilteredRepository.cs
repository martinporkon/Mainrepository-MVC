using System.Net.Http;
using SooduskorvWebMVC.Domain.DTO.Common;
using WebMVC.Domain.Common;

namespace WebMVC.Infra.Common
{
    public class FilteredRepository<TDomain, TData> : SortedRepository<TDomain, TData>, IFiltering
        where TDomain : IDto<TData>
        where TData : PeriodDto, new()
    {
        public string SearchString { get; set; }
        public string CurrentFilter { get; set; }
        public string FixedFilter { get; set; }
        public string FixedValue { get; set; }

        public FilteredRepository(IHttpClientFactory h, string baseAddress) : base(h, baseAddress)
        {
        }
    }
}