using Catalog.Domain;

namespace Catalog.Infra.Common
{
    public abstract class FilteredRepository<TDomain, TData> : SortedRepository<TDomain, TData>, IFiltering
    {
        public string SearchString { get; set; }
        public string CurrentFilter { get; set; }
        public string FixedFilter { get; set; }
        public string FixedValue { get; set; }
    }
}