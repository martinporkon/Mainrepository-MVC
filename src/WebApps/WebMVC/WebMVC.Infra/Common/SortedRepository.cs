using System.Net.Http;
using System.Threading.Tasks;
using Web.Domain.Common;
using Web.Domain.DTO.Common;

namespace Web.Infra.Common
{
    public class SortedRepository<TDomain, TData> : BaseRepository<TDomain, TData>, ISorting
        where TDomain : IDto<TData>
        where TData : PeriodEntityDto, new()
    {
        public string SortOrder { get; set; }
        public string DescendingString => "_desc";

        public SortedRepository(IHttpClientFactory h, string baseAddress) : base(h, baseAddress)
        {
        }
    }
}