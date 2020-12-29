using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Basket.Pages
{
    public class BasketsPage : PageModel
    {
        public void OnGetIndex()
        {

        }
        public string Caption { get; protected set; }

        public BasketsPage()
        {
            Caption = "Baskets";
        }
    }
}
