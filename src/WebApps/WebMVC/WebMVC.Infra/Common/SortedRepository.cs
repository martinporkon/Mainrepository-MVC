using System.Net.Http;
using SooduskorvWebMVC.Domain.DTO.Common;
using WebMVC.Domain.Common;

namespace WebMVC.Infra.Common
{
    public class SortedRepository<TDomain, TData> : BaseRepository<TDomain, TData>, ISorting
        where TDomain : IDto<TData>
        where TData : PeriodDto, new()
    {
        public string SortOrder { get; set; }

        public SortedRepository(IHttpClientFactory h, string baseAddress) : base(h, baseAddress)
        {
        }
    }
}