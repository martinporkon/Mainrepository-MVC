using System.Collections.Generic;
using System.Threading.Tasks;
using WebMVC.Bff.HttpAggregator.Domain.DTO;

namespace WebMVC.Bff.HttpAggregator.Domain.CatalogService
{
    public interface ICatalogServiceRepository
    {
        Task<IEnumerable<ProductDto>> GetAll();
        Task<ProductDto> GetById(string id);
    }
}