using System.Net.Http;
using SooduskorvWebMVC.Domain.DTO.Common;
using WebMVC.Domain.Common;

namespace WebMVC.Infra.Common
{
    public class PaginatedRepository<TDomain, TData> : FilteredRepository<TDomain, TData>, IPaging
        where TDomain : IDto<TData>
        where TData : PeriodDto, new()
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; }
        public bool HasNextPage { get; }
        public bool HasPreviousPage { get; }

        public PaginatedRepository(IHttpClientFactory h, string baseAddress) : base(h, baseAddress)
        {
        }
    }
}