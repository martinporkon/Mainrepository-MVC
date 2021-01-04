using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sooduskorv_MVC.Data.CommonData;
using Web.Domain.Common;

namespace Web.Infra.Common
{
    public abstract class UniqueRepository<TDomain, TData> : PaginatedRepository<TDomain, TData>
        where TDomain : IEntity<TData>
        where TData : PeriodData, new()
    {
        protected UniqueRepository(HttpClient h, string baseAddress, HttpMethod m,
            CancellationToken t)
            : base(h, baseAddress, m, t)
        {

        }

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