using System.Threading.Tasks;
using SooduskorvWebMVC.Models;

namespace WebMVC.Domain.Services
{
    public interface IProductsService
    {
        Task<ProductDto> GetProducts();
    }
}