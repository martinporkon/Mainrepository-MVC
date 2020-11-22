using Catalog.Domain;

namespace Catalog.Infra.Common
{
    public abstract class SortedRepository<TDomain, TData> : BaseRepository<TDomain, TData>, ISorting
    {
        public string SortOrder { get; set; }
    }
}