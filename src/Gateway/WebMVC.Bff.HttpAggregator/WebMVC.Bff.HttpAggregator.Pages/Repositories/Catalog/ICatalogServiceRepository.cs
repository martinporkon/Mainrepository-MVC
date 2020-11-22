using System.Collections.Generic;
using System.Threading.Tasks;
using WebMVC.Bff.HttpAggregator.Domain.DTO;

namespace WebMVC.Bff.HttpAggregator.Infra.Repositories
{
    public interface ICatalogServiceRepository
    {
        Task<IEnumerable<ProductDto>> GetAll();
        Task<ProductDto> GetById(string id);
    }
}