using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Basket.Domain.Common;
using Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using Sooduskorv_MVC.Data.CommonData;

namespace Basket.Infra.Common
{
    public class BaseRepository<TDomain, TData> : ICrudMethods<TDomain>, IRepository
        where TDomain : IEntity<TData>
        where TData : PeriodData
    {
        protected internal DbContext db;
        protected internal DbSet<TData> dbSet;

        protected BaseRepository(DbContext c, DbSet<TData> s)
        {
            db = c;
            dbSet = s;
        }

        public Task<List<TDomain>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<TDomain> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task Add(TDomain obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(TDomain obj)
        {
            throw new NotImplementedException();
        }

        public object GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}