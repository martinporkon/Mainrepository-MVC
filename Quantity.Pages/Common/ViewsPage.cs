﻿using System;
using CommonData;
using Quantity.Domain.Common;
using Quantity.Facade.Common;
using Quantity.Pages.Common;

namespace Quanity.Pages.Common
{
    public abstract class ViewsPage<TRepository, TDomain, TView, TData> :
        ViewPage<TRepository, TDomain, TView, TData>
        where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
        where TDomain : IEntity<TData>
        where TData : PeriodData, new()
        where TView : PeriodView
    {
        protected ViewsPage(TRepository r, string title) : base(r, title) { }

        protected internal Uri createUri(int i)
        {
            var uri = CreateUrl.ToString();
            uri += $"&switchOfCreate={i}";

            return new Uri(uri, UriKind.Relative);
        }
    }
}
