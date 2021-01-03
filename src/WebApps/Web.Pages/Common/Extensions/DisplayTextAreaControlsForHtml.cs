using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Pages.Common.Extensions
{
    public static class DisplayTextAreaControlsForHtml
    {
        public static IHtmlContent DisplayTextAreaControlsFor<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression)
        {

            var s = HtmlStrings(htmlHelper, expression);

            return new HtmlContentBuilder(s);
        }

        internal static List<object> HtmlStrings<TModel, TResult>(IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TResult>> expression)
        {
            return new List<object> {
                new HtmlString("<dt class=\"col-sm-2\">"),
                htmlHelper.DisplayNameFor(expression),
                new HtmlString("</dt>"),
                new HtmlString("<dd class=\"col-sm-10\">"),
                htmlHelper.DisplayFor(expression, new {@class = "text-dark", resize="none", rows="10", placeholder="20%"}),
                new HtmlString("</dd>")
            };
        }
    }
}