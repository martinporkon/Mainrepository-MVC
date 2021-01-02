using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Catalog.Pages.Common.Extensions
{

    public static class EditorHtml
    {

        public static IHtmlContent Editor<TModel, TResult>(
            this IHtmlHelper<TModel> h,
            Expression<Func<TModel, TResult>> e)
        {

            var s = htmlStrings(h, e);

            return new HtmlContentBuilder(s);
        }

        internal static List<object> htmlStrings<TModel, TResult>(
            IHtmlHelper<TModel> h,
            Expression<Func<TModel, TResult>> e)
        {

            return new List<object> {
                new HtmlString("<div class=\"form-group\">"),
                h.LabelFor(e, new {@class = "text-dark"}),
                h.EditorFor(e,
                    new {htmlAttributes = new {@class = "form-control"}}),
                h.ValidationMessageFor(e, "", new {@class = "text-danger"}),
                new HtmlString("</div>")
            };
        }

    }

}
