﻿using System.Net.Http;
using System.Threading;
using Sooduskorv_MVC.Data.CommonData;
using Web.Domain.Common;

namespace Web.Infra.Common
{
    public abstract class FilteredRepository<TDomain, TData> : SortedRepository<TDomain, TData>, IFiltering
        where TDomain : IEntity<TData>
        where TData : PeriodData, new()
    {
        public string SearchString { get; set; }
        public string CurrentFilter { get; set; }
        public string FixedFilter { get; set; }
        public string FixedValue { get; set; }

        protected FilteredRepository(HttpClient h, string baseAddress, HttpMethod m,
            CancellationToken t) : base(h, baseAddress, m, t) { }

        /*protected internal override HttpClient getValuesFrom()
        {
            var response = base.getValuesFrom();
        }*/

        // TODO add the string features to the query request


    }
}