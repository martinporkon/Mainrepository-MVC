using System.Net.Http;
using Web.Domain.Common;
using Web.Domain.DTO.Common;

namespace Web.Infra.Common
{
    public class PaginatedRepository<TDomain, TData> : FilteredRepository<TDomain, TData>, IPaging
        where TDomain : IDto<TData>
        where TData : PeriodEntityDto, new()
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