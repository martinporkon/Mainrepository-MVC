using System;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Domain.Common;
using Web.Domain.DTO.Common;

namespace Web.Infra.Common
{
    public class UniqueRepository<TDomain, TData> : PaginatedRepository<TDomain, TData>
        where TDomain : IDto<TData>
        where TData : UniqueEntityDto, new()
    {
        public UniqueRepository(IHttpClientFactory h, string baseAddress) : base(h, baseAddress) { }

        protected override async Task<TData> getData(string id)
        {
            throw new NotImplementedException();
        }

        protected override TData getDataById(TData d)
        {
            throw new NotImplementedException();
        }
    }
}