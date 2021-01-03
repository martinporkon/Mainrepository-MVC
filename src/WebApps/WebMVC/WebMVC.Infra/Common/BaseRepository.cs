using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Domain.Common;
using Web.Domain.DTO.Common;

namespace Web.Infra.Common
{
    public abstract class BaseRepository<TDomain, TData> : ICrudMethods<TDomain>, IRepository
        where TDomain : IDto<TData>
        where TData : PeriodEntityDto, new()
    {
        private readonly IHttpClientFactory h;
        private readonly string _baseAddress;

        protected BaseRepository(IHttpClientFactory h, string baseAddress)
        {
            this.h = h;
            _baseAddress = baseAddress;
        }

        public async Task<List<TDomain>> Get()
        {
            throw new System.NotImplementedException();
        }

        public async Task<TDomain> Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task Add(TDomain obj)
        {
            throw new System.NotImplementedException();
        }

        public async Task Update(TDomain obj)
        {
            throw new System.NotImplementedException();
        }

        public object GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        protected internal abstract TDomain toDomainObject(TData periodData);

        protected abstract Task<TData> getData(string id);

        protected TData getData(TDomain obj) => obj?.Data;

        protected abstract TData getDataById(TData d);
    }
}