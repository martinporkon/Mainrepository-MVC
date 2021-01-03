using Web.Domain.DTO.CatalogService;
using Web.Domain.Services.Catalogs;
using Web.Infra.Common;

namespace Web.Infra.Catalog
{
    public class CatalogRepository : UniqueRepository<Domain.Services.Catalogs.Catalog, CatalogDto>, ICatalogsService
    {

    }
}