using Microsoft.Extensions.DependencyInjection;
using Web.Domain.Services.Catalogs;
using Web.Infra.Catalog;

namespace Web.Infra.Common
{
    public class WebInfra
    {
        public void RegisterServices(IServiceCollection s)
        {
            s.AddHttpClient<ICatalogsService, CatalogRepository>();
        }
    }
}