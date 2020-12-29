using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SooduskorvWebMVC.Domain.DTO.Common;
using WebMVC.Domain.Common;

namespace WebMVC.Infra.Common
{
    public abstract class BaseRepository<TDomain, TData> : ICrudMethods<TDomain>, IRepository
        where TDomain : IDto<TData>
        where TData : PeriodDto, new()
    {
        private readonly IHttpClientFactory h;
        private readonly string _baseAddress;

        protected BaseRepository(IHttpClientFactory h, string baseAddress)
        {
            this.h = h;
            _baseAddress = baseAddress;
        }

        public Task<List<TDomain>> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<TDomain> Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task Add(TDomain obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(TDomain obj)
        {
            throw new System.NotImplementedException();
        }

        public object GetById(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}