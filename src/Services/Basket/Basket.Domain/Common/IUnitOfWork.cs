using System;
using System.Threading.Tasks;
using Basket.Domain.BasketOfProducts;
using Basket.Domain.Baskets;

namespace Basket.Domain.Common
{
    public interface IUnitOfWork/*<out TContext> */: IDisposable
    /*where TContext : DbContext, new()*/
    {
        /*TContext Context { get; }*/
        //https://dotnettutorials.net/lesson/unit-of-work-csharp-mvc/
        IBasketRepository BasketRepository { get; }
        IBasketOfProductRepository BasketOfProductRepository { get; }

        Task<bool> SaveChangesAsync();
        void Rollback();
    }
}