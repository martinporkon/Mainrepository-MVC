﻿using Catalog.Data.Product;
using Catalog.Domain.Catalog;
using Catalog.Domain.Product;
using Catalog.Infra.Common;

namespace Catalog.Infra.Catalog
{

    public sealed class ProductCategoriesRepository : UniqueEntityRepository<ProductCategory, ProductCategoryData>,
        IProductCategoriesRepository
    {

        public ProductCategoriesRepository(CatalogDbContext c = null) : base(c, c?.ProductCategories) { }

        protected internal override ProductCategory toDomainObject(ProductCategoryData d) => new ProductCategory(d);

    }

}