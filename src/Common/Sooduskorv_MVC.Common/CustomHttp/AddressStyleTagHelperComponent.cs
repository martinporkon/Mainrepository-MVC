using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Sooduskorv_MVC.Common.Http
{
    public class AddressStyleTagHelperComponent : TagHelperComponent
    {
        private readonly string _style =// TODO fix this.
            @"<link rel=""stylesheet"" href=""~/css/catalog/catalog.component.css"" />";
        public override int Order => 1;

        public override Task ProcessAsync(TagHelperContext context,
            TagHelperOutput output)
        {
            if (string.Equals(context.TagName, "head",
                StringComparison.OrdinalIgnoreCase))
            {
                output.PostContent.AppendHtml(_style);
            }

            return Task.CompletedTask;
        }
    }
}