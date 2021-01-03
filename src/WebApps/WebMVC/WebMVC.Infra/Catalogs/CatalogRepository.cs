using System.Net.Http;
using Web.Domain.DTO.CatalogService;
using Web.Domain.Services.Catalogs;
using Web.Infra.Common;

namespace Web.Infra.Catalog
{
    public class CatalogRepository : UniqueRepository<Domain.Services.Catalogs.Catalog, CatalogDto>, ICatalogsService
    {
        public CatalogRepository(IHttpClientFactory h, string baseAddress) : base(h, baseAddress) { }

        protected internal override Domain.Services.Catalogs.Catalog toDomainObject(CatalogDto d)
            => new Domain.Services.Catalogs.Catalog(d);
    }
}