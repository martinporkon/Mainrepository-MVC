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