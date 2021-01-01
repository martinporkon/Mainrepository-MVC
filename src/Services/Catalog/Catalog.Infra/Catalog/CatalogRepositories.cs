using Catalog.Domain.Catalog;
using Catalog.Domain.Prices;
using Catalog.Domain.Product;
using Catalog.Infra.Prices;
using Catalog.Infra.Product;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infra.Catalog
{
    public static class CatalogRepositories
    {

        public static void Register(IServiceCollection services)
        {
           
            services.AddScoped<ICatalogsRepository, CatalogsRepository>();
            services.AddScoped<ICatalogEntriesRepository, CatalogEntriesRepository>();
            services.AddScoped<ICatalogedProductsRepository, CatalogedProductsRepository>();
            services.AddScoped<IProductCategoriesRepository, ProductCategoriesRepository>();
            services.AddScoped<IProductTypesRepository, ProductTypesRepository>();
            services.AddScoped<IProductInstancesRepository, ProductInstancesRepository>();
            services.AddScoped<IBrandsRepository, BrandsRepository>();
            services.AddScoped<IPricesRepository, PricesRepository>();


        }
    }
}
