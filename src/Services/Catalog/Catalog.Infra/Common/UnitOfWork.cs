using System;

namespace Catalog.Domain.Common
{
    public class UnitOfWork : IUnitOfWork
    {

        public void SaveChangesAsync()
        {
            return _context.SaveChanges() > 0;
        }

        public void Rollback()
        {

        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}