using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Nupp.Services
{
    public class CatalogItemBase : ComponentBase
    {
        [Inject]
        public IBasketService BasketService { get; set; }

        public CatalogItemBase()
        {

        }
        protected override async Task OnInitializedAsync()
        {
            await BasketService.PostToBasket();
        }

        protected override Task OnParametersSetAsync()
        {
            return base.OnParametersSetAsync();
        }
    }
}