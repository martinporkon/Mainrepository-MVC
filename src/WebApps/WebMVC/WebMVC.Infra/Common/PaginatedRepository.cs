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
        public int TotalPages => getTotalPages(PageSize);
        public bool HasNextPage => PageIndex < TotalPages;
        public bool HasPreviousPage => PageIndex > 1;

        public PaginatedRepository(IHttpClientFactory h, string baseAddress) : base(h, baseAddress) { }

        internal int getTotalPages(in int pageSize)
        {
            /*var count = getItemsCount();
            var pages = countTotalPages(count, pageSize);*/
            // TODO
            return pageSize;
        }
    }
}