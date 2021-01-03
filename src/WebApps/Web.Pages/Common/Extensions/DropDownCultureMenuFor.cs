using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Pages.Common.Extensions
{
    /// <summary>
    /// TODO
    /// </summary>
    public static class DropDownCultureMenuFor
    {
        internal static void addDropDownMenuItem(List<object> htmlStrings, Link item)
        {
            if (htmlStrings is null) return;
            if (item is null) return;
            var s = $"<a class='dropdown-item text-dark' href=\"{item.Url}\">{item.DisplayName}</a>";
            htmlStrings.Add(new HtmlString(s));
        }

        internal static void beginDropDownCultureMenu(List<object> htmlStrings, string name)
        {
            if (htmlStrings is null) return;
            htmlStrings.Add(new HtmlString("<li class=\"nav-item dropdown\">"));
            htmlStrings.Add(new HtmlString(
                "<a class=\"nav-link text-dark dropdown-toggle\" href=\"#\" id=\"navbardrop\" data-toggle=\"dropdown\">"));
            htmlStrings.Add(new HtmlString(name));
            htmlStrings.Add(new HtmlString("</a>"));
            htmlStrings.Add(new HtmlString("<div class=\"dropdown-menu\">"));
        }

        internal static void endDropDownCultureMenu(List<object> htmlStrings)
        {
            if (htmlStrings is null) return;
            htmlStrings.Add(new HtmlString("</div>"));
            htmlStrings.Add(new HtmlString("</li>"));
        }

        public static IHtmlContent
            DropDownCultureMenu(this IHtmlHelper helper, string name, params Link[] items)
        {
            var strings = HtmlStrings(name, items);
            return new HtmlContentBuilder(strings);
        }

        internal static List<object> HtmlStrings(string name, params Link[] items)
        {
            var list = new List<object>();
            beginDropDownCultureMenu(list, name);
            foreach (var item in items) addDropDownMenuItem(list, item);
            endDropDownCultureMenu(list);

            return list;
        }
    }
}

/*< div >
< form id = "culture-switcher" >
 
< select name = "culture" id = "culture-options" >
    
< !--Into HTML extension-->
<option></option>
@foreach (var culture in Model.SupportedCultures)
{
< option value = "@culture.Name" selected = "@(Model.CurrentUICulture.Name == culture.Name)" > @culture.DisplayName </ option >
}
</ select >
</ form >

< form method = "GET" >
 
< div class= "form-group" >
  
    < label class= "sr-only" for= "culture-picker" >
CultureFor:

</ label >
    
< select id = "culture-picker" class= "form-control" name = "culture" onchange = "this.parentElement.parentElement.submit();" >
@foreach(var culture in Model.SupportedCultures)
{
< option value = "@culture.Name" selected = "@(Model.CurrentUICulture.Name == culture.Name)" > @culture.DisplayName </ option >
}
</ select >
</ div >
</ form >
</ div >*/