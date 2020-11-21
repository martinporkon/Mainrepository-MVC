using Catalog.Domain.Catalog;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

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
      
        }
    }
}
