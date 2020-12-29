using System.Net.Http;
using SooduskorvWebMVC.Domain.DTO.Common;
using WebMVC.Domain.Common;

namespace WebMVC.Infra.Common
{
    public class UniqueRepository<TDomain, TData> : PaginatedRepository<TDomain, TData>
        where TDomain : IDto<TData>
        where TData : UniqueDto, new()
    {
        public UniqueRepository(IHttpClientFactory h, string baseAddress) : base(h, baseAddress)
        {
        }
    }
}