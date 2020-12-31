using System.ComponentModel;
using System.Net.Http;
using Microsoft.AspNetCore.Components;

namespace Nupp.Views.Home.Button
{
    public class SendBasketItemBase : ComponentBase
    {
        [Inject]
        private HttpClient HttpClient { get; set; }
        public int TotalSelectedItemsCount { get; set; } = 0;
        [Parameter]
        public RenderFragment CustomMessage { get; set; }
    }
}