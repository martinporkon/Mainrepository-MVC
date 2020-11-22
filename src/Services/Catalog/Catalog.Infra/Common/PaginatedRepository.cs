using Catalog.Domain;

namespace Catalog.Infra.Common
{
    public abstract class PaginatedRepository<TDomain, TData> : FilteredRepository<TDomain, TData>, IPaging
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; }
        public bool HasNextPage { get; }
        public bool HasPreviousPage { get; }
    }
}