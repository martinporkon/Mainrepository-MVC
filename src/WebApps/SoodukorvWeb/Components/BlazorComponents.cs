using Microsoft.Extensions.DependencyInjection;

namespace SooduskorvWebMVC.Components
{
    public static class BlazorComponents
    {
        public static void Register(IServiceCollection s)
        {
            s.AddScoped<ViewState>();
            s.AddScoped<SendBasketItemBase>();
            s.AddScoped<DisplayBasketItemBase>();
            s.AddScoped<CatalogItemBase>();
        }
    }
}