using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sooduskorv_MVC.Aids.Enums;

namespace SooduskorvWebMVC.Pages.Extensions
{
    public static class PagingForHtmlExtension
    {
        public static IHtmlContent PagingFor(
            this IHtmlHelper htmlHelper, string page, string sortOrder,
            string fixedFilter, string fixedValue, int pageIndex,
            string searchString, bool hasPreviousPage, bool hasNextPage,
            int totalPages)
        {
            var prevDisabled = !hasPreviousPage ? "disabled" : "";
            var nextDisabled = !hasNextPage ? "disabled" : "";

            var s = HtmlStrings(page, sortOrder, fixedFilter,
                fixedValue, pageIndex, searchString,
                prevDisabled, nextDisabled, totalPages);

            return new HtmlContentBuilder(s);
        }

        internal static List<object> HtmlStrings(string page, string sortOrder, string fixedFilter,
            string fixedValue, int pageIndex, string searchString,
            string prevDisabled, string nextDisabled, int totalPages)
        {
            var list = new List<object>
            {
                new HtmlString("<div class=\"form-inline\">"),
                new HtmlString($"<a href=\"{page}?sortOrder={sortOrder}&pageIndex={pageIndex}&currentFilter={searchString}&fixedFilter={fixedFilter}&fixedValue={fixedValue}\" class=\"btn btn-link {prevDisabled}\" >{PagingType.CurrentPage}</a>"),
                new HtmlString("&nbsp;"),
                new HtmlString($"<a href=\"{page}?sortOrder={sortOrder}&pageIndex={pageIndex - 1}&currentFilter={searchString}&fixedFilter={fixedFilter}&fixedValue={fixedValue}\" class=\"btn btn-link {prevDisabled}\" >{PagingType.PreviousPage}</a>"),
                new HtmlString("&nbsp;"),
                new HtmlString($"Page {pageIndex} of {totalPages}"),
                new HtmlString("&nbsp;"),
                new HtmlString($"<a href=\"{page}?sortOrder={sortOrder}&pageIndex={pageIndex + 1}&currentFilter={searchString}&fixedFilter={fixedFilter}&fixedValue={fixedValue}\" class=\"btn btn-link {nextDisabled}\" >{PagingType.NextPage}</a>"),
                new HtmlString("&nbsp;"),
                new HtmlString($"<a href=\"{page}?sortOrder={sortOrder}&pageIndex={totalPages}&currentFilter={searchString}&fixedFilter={fixedFilter}&fixedValue={fixedValue}\" class=\"btn btn-link {nextDisabled}\" >{PagingType.LastPage}</a>"),
                new HtmlString("</div>")
            };
            return list;
        }
    }
}