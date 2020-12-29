using System.Threading.Tasks;
using SooduskorvWebMVC.Models;

namespace WebMVC.Domain.Services.Catalog
{
    public interface IProductsService
    {
        Task<ProductDto> GetProducts();
    }
}