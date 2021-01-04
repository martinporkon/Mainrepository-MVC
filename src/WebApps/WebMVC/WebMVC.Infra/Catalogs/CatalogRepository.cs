using System.Net.Http;
using System.Threading;
using Web.Domain.DTO.CatalogService;
using Web.Domain.Services.Catalogs;
using Web.Infra.Common;

namespace Web.Infra.Catalog
{
    public sealed class CatalogRepository : UniqueRepository<Domain.Services.Catalogs.Catalog, CatalogDto>, ICatalogsService
    {
        public CatalogRepository(IHttpClientFactory h, string baseAddress, HttpMethod m,
            CancellationToken t)
            : base(h, baseAddress, m, t) { }

        protected internal override Domain.Services.Catalogs.Catalog toDomainObject(CatalogDto d)
            => new Domain.Services.Catalogs.Catalog(d);
    }
}