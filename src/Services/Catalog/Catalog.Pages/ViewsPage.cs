using Catalog.Domain;
using Catalog.Domain.Common;
using Sooduskorv_MVC.Data.CommonData;
using System;

namespace Catalog.Pages
{
    public abstract class ViewsPage<TRepository, TDomain, TView, TData> :
        ViewPage<TRepository, TDomain, TView, TData>
        where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
        where TDomain : IEntity<TData>
        where TData : UniqueEntityData, new()
        where TView : UniqueEntityView
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
