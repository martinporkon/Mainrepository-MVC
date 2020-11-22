using System;
using System.Threading.Tasks;
using Basket.Domain.BasketOfProducts;
using Basket.Domain.Baskets;
using Basket.Infra;
using Basket.Infra.BasketOfProducts;
using Basket.Infra.Baskets;

namespace Basket.Domain.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BasketDbContext _context;

        public UnitOfWork(BasketDbContext context)
        {
            _context = context;
        }

        private IBasketRepository _basketRepository;
        public IBasketRepository BasketRepository => _basketRepository ??= new BasketRepository(_context);

        private IBasketOfProductRepository _basketOfProductRepository;
        public IBasketOfProductRepository BasketOfProductRepository => _basketOfProductRepository ??= new BasketOfProductRepository(_context);

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Rollback()
        {

        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                _context?.DisposeAsync();
                // _basketRepository?.Dispose();
                // _basketOfProductRepository.)Dispose()
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}