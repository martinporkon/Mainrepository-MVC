using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Sooduskorv_MVC.Common.Http
{
    public class SendAsyncTagHelperComponent : TagHelperComponent
    {
        public SendAsyncTagHelperComponent()
        {
            throw new NotImplementedException("https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/th-components?view=aspnetcore-5.0");
        }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            return base.ProcessAsync(context, output);// sama blazori jaoks koodile.
        }
    }
}