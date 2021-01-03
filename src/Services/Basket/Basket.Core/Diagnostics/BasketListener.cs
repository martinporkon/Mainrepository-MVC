using Microsoft.Extensions.DiagnosticAdapter;

namespace Basket.Core.Diagnostics
{
    public class BasketListener
    {
        [DiagnosticName(nameof(OnBasketComposed))]
        public void OnBasketComposed()
        {

        }

        [DiagnosticName(nameof(OnProductAdded))]
        public void OnProductAdded()
        {

        }

        [DiagnosticName(nameof(OnOrderComposed))]
        public void OnOrderComposed()
        {

        }
    }
}