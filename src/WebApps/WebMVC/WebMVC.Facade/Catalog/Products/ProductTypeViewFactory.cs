using System;
using Web.Domain.DTO.CatalogService;
using Web.Domain.Services.Catalog.Products.ProductTypes;
using Web.Facade.Common;

namespace Web.Facade.Profiles.Catalog.Products
{
    public class ProductTypeViewFactory : AbstractViewFactory<ProductTypeDto, ProductType, ProductTypeView>
    {
        protected internal override ProductType toObject(ProductTypeDto d) => new ProductType(d);
        public override ProductTypeView Create(ProductType o)
        {
            throw new NotImplementedException();
        }
    }
}