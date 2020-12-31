using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Nupp.Views.Home.Button
{
    public class CatalogItemBase : ComponentBase
    {
        static RenderFragment RenderFragment = build =>
        {
            build.OpenElement(1, "button"); //Open Element
            build.AddAttribute(2, $"background-color:...");
            build.CloseComponent(); //Close Element
        };
    }
}