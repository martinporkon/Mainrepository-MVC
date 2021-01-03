using Web.Domain.Common;
using Web.Domain.DTO.CatalogService;
using Web.Domain.DTO.Common;

namespace Web.Domain.Services.Catalogs
{
    public sealed class Catalog : UniqueEntity<CatalogDto>
    {
        public Catalog(CatalogDto d) : base(d) { }

        // TODO properties

        public string Name => Data?.Name ?? Unspecified;
        public string Description => Data?.Description ?? Unspecified;
    }
}