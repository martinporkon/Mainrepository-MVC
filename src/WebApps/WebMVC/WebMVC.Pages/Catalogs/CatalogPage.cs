using Basket.Pages.Common;
using SooduskorvWebMVC.Models;
using WebMVC.Domain.Common;
using WebMVC.Facade.Profiles.CatalogView;

namespace WebMVC.Pages.Catalogs
{
    public class CatalogPage/* : ViewsPage<ICatalogRepository, CatalogRepository, CatalogView, CatalogDto>*/
    /*where ICatalogRepository : ICrudMethods<CatalogView>*/
    {
        public CatalogPage()
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