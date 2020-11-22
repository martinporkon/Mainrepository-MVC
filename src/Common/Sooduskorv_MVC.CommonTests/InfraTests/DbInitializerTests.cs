
using CommonTests.OverallTests;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests.InfraTests
{

    public class DbInitializerTests<TDbContext> : BaseTests where TDbContext : DbContext
    {

        protected TDbContext db;
        protected DbContextOptions<TDbContext> options;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            options = new DbContextOptionsBuilder<TDbContext>().UseInMemoryDatabase("TestDb").Options;
        }
        protected void removeAll<TData>(DbSet<TData> set) where TData : class, new() => removeAll(set, db);

    }

}
