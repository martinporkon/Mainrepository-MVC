using Catalog.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Pages
{
    public abstract class BasePage<TRepository, TDomain, TData> : ControllerBase
    where TRepository : ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
    {
        protected TRepository db { get; }
        protected BasePage(TRepository r) => db = r;
    }
}