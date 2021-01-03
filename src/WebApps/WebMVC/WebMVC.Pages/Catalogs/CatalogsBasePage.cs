using Web.Domain.Common;
using Web.Domain.DTO.CatalogService;
using Web.Domain.Services.Catalogs;
using Web.Facade.Catalogs.CatalogView;
using Web.Pages.Common;

namespace Web.Pages.Catalogs
{
    public class CatalogsBasePage : ViewsPage<CatalogsBasePage, CatalogRepository, Catalog, CatalogView, CatalogDto>
    {
        public CatalogsBasePage()
        {

        }
    }

    public class CatalogRepository
    {
    }

    public interface ICatalogRepository : ISorting
    {
    }
}