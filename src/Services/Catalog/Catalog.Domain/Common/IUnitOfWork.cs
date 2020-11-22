using System;

namespace Catalog.Domain.Common
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChangesAsync();
        void Rollback();
    }
}