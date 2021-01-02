using System.Threading.Tasks;

namespace WebMVC.Domain.Services.Catalog
{
    public interface IProductsService
    {
        Task<ProductDto> GetProducts();
    }

    public class ProductDto
    {
        public string Id { get; set; }
        public object PartyId { get; set; }
    }
}