using System.Net.Http;
using Web.Domain.DTO.CatalogService;
using Web.Domain.Services.Catalogs;
using Web.Infra.Common;

namespace Web.Infra.Catalog
{
    public sealed class CatalogRepository : UniqueRepository<Domain.Services.Catalogs.Catalog, CatalogDto>, ICatalogsService
    {
        public CatalogRepository(IHttpClientFactory h, string baseAddress, HttpMethod m) : base(h, baseAddress, m) { }

        protected internal override Domain.Services.Catalogs.Catalog toDomainObject(CatalogDto d)
            => new Domain.Services.Catalogs.Catalog(d);
    }
}