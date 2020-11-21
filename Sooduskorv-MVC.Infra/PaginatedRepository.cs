using Catalog.Domain;
using Catalog.Domain.Common;
using CommonData;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sooduskorv_MVC.Infra
{
    public abstract class PaginatedRepository<TDomain, TData> : FilteredRepository<TDomain, TData>, IPaging
        where TDomain : IEntity<TData>
        where TData : UniqueEntityData, new()
    {

        public int PageIndex { get; set; }
        public int TotalPages => getTotalPages(PageSize);
        public bool HasNextPage => PageIndex < TotalPages;
        public bool HasPreviousPage => PageIndex > 1;
        public int PageSize { get; set; } = 5;

        protected PaginatedRepository(DbContext c, DbSet<TData> s) : base(c, s) { }

        internal int getTotalPages(in int pageSize)
        {
            var count = getItemsCount();
            var pages = countTotalPages(count, pageSize);

            return pages;
        }

        internal int countTotalPages(int count, in int pageSize) => (int)Math.Ceiling(count / (double)pageSize);

        internal int getItemsCount() => base.createSqlQuery().CountAsync().Result;

        protected internal override IQueryable<TData> createSqlQuery() => addSkipAndTake(base.createSqlQuery());

        private IQueryable<TData> addSkipAndTake(IQueryable<TData> query)
        {
            if (PageIndex < 1) return query;

            return query
                .Skip((PageIndex - 1) * PageSize)
                .Take(PageSize);
        }

    }
}
