using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Web.Domain.Common;
using Web.Domain.DTO.Common;

namespace Web.Infra.Common
{
    public abstract class BaseRepository<TDomain, TData> : ICrudMethods<TDomain>, IRepository
        where TDomain : IDto<TData>
        where TData : PeriodEntityDto, new()
    {
        public string BaseAddress { get; set; }
        protected CancellationTokenSource CancellationToken
            = new CancellationTokenSource();
        private readonly IHttpClientFactory h;
        private readonly HttpMethod Method;
        private readonly CancellationToken _t;

        protected BaseRepository(IHttpClientFactory h, string baseAddress, HttpMethod m,
            CancellationToken t)
        {
            this.h = h;
            Method = m;
            /*_t.Token = t;*/
            BaseAddress = baseAddress;
        }


        public async Task<List<TDomain>> Get()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "api/mvc-bff/products");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("brotli"));


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

        protected internal virtual HttpClient getValuesFrom()
        {
            var query = h.CreateClient();
            return query;
        }




        protected abstract Task<TData> getData(string id);

        protected TData getData(TDomain obj) => obj?.Data;

        protected abstract TData getDataById(TData d);
    }
}