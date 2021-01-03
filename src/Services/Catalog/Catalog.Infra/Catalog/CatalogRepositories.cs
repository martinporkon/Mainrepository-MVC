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
            services.AddScoped<ICatalogedProductsRepository, CatalogedProductsRepository>();
            services.AddScoped<ICatalogEntriesRepository, CatalogEntriesRepository>();
            services.AddScoped<ICatalogsRepository, CatalogsRepository>();
            services.AddScoped<IProductCategoriesRepository, ProductCategoriesRepository>();
            services.AddScoped<IPricesRepository, PricesRepository>();
            services.AddScoped<IBrandsRepository, BrandsRepository>();
            services.AddScoped<IProductInstancesRepository, ProductInstancesRepository>();
            services.AddScoped<IProductTypesRepository, ProductTypesRepository>();



        }
    }
}