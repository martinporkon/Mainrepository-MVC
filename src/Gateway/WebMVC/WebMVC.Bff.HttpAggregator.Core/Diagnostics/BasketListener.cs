using Microsoft.Extensions.DiagnosticAdapter;

namespace WebMVC.Bff.HttpAggregator.Core.Diagnostics
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
    }
}