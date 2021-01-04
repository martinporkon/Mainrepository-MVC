using System.Net.Http;
using System.Threading;
using Web.Domain.DTO.CatalogService;
using Web.Domain.Services.Catalog.Products.ProductTypes;
using Web.Infra.Common;

namespace Web.Infra.Catalog.Products
{

    public sealed class ProductTypesRepository : UniqueRepository<IProductType, ProductTypeDto>,
        IProductTypesRepository
    {

        public ProductTypesRepository(HttpClient h, string b, HttpMethod m,
            CancellationToken t) : base(h, b, m, t) { }

        protected internal override IProductType toDomainObject(ProductTypeDto d) => ProductTypeFactory.Create(d);

    }

}

// TODO HttMEssageRequst or string handler builder
// TODO that builds the string and the inserts it into the request uri.