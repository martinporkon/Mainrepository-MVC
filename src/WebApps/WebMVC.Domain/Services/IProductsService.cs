using System.Threading.Tasks;
using WebMVC.Facade.Models.Catalog;

namespace WebMVC.Domain.Services
{
    public interface IProductsService
    {
        Task<ProductDto> GetProducts();
    }
}