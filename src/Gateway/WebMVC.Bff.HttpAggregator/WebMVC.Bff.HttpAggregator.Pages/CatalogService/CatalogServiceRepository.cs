using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMVC.Bff.HttpAggregator.Domain.DTO;

namespace WebMVC.Bff.HttpAggregator.Infra.Repositories
{
    public class CatalogServiceRepository : ICatalogServiceRepository
    {
        public CatalogServiceRepository()
        {

        }

        public Task<IEnumerable<ProductDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}