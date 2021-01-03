using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;

namespace Web.Pages.Common.Extensions
{
    public static class DisplayImageForHtmlExtension
    {
        public static IHtmlContent DisplayImageFor<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, byte[] image, string alternateText, object htmlAttributes)
        {
            var s = HtmlStrings(htmlHelper, image, alternateText, htmlAttributes);

            return new HtmlContentBuilder(s);
        }

        internal static List<object> HtmlStrings<TModel>(IHtmlHelper<TModel> htmlHelper, byte[] image, string alternateText, object htmlAttributes)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", $"{Constants.ImageType}, {Convert.ToBase64String(image)}");
            builder.MergeAttribute("alt", alternateText);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return new List<object> { builder };
        }
    }
}