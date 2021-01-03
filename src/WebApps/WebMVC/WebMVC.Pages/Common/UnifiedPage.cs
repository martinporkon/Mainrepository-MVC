using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Domain.Common;
using Web.Facade.Common;
using Web.Pages.Common.Extensions;
using System.Linq.Expressions;
using System.Collections.Generic;
using Web.Domain.DTO.Common;

namespace Web.Pages.Common
{
    public abstract class UnifiedPage<TPage, TRepository, TDomain, TView, TData>
        : TitledPage<TRepository, TDomain, TView, TData>//, IIndexTable<TPage>
        where TPage : PageModel
        where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
        where TDomain : IDto<TData>
        where TData : PeriodEntityDto, new()
        where TView : PeriodView
    {
        protected UnifiedPage(TRepository r, string title) : base(r, title) { }

        public List<LambdaExpression> Columns { get; }
            = new List<LambdaExpression>();

        protected Expression<Func<TPage, TResult>> toExpr<TResult>(LambdaExpression e)
            => e as Expression<Func<TPage, TResult>>;

        public int ColumnsCount => Columns?.Count ?? -1;

        public int RowsCount => Items?.Count ?? -1;

        public string Undefined => "Undefined";
    }
}