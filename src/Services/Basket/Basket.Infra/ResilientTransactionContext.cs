using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Basket.Infra
{
    /// <summary>
    /// TODO UnitOfWork pattern integration ?
    /// </summary>
    public class ResilientTransactionContext
    {
        private readonly DbContext _context;
        public static ResilientTransactionContext New(DbContext context)
            => new ResilientTransactionContext(context);
        private ResilientTransactionContext(DbContext context)
        {
            _context = context
                       ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task ExecuteAsync(Func<Task> action)
        {
            var strategy = _context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await _context.Database.BeginTransactionAsync();
                await action();
                await transaction.CommitAsync();
            });
        }
    }
}