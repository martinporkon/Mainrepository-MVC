using Catalog.Data.UserProfiles;
using Catalog.Infra;
using CommonTests.InfraTests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Tests.Infra
{
    [TestClass]
    public class CatalogDbContextTests : DbContextTests<CatalogDbContext, DbContext>
    {
        private ModelBuilder modelBuilder;
        private class testClass : CatalogDbContext
        {

            public testClass(DbContextOptions<CatalogDbContext> o) : base(o) { }

            public ModelBuilder RunOnModelCreating()
            {
                var set = new ConventionSet();
                var mb = new ModelBuilder(set);
                OnModelCreating(mb);

                return mb;
            }
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            options = new DbContextOptionsBuilder<CatalogDbContext>().UseInMemoryDatabase("TestDb").Options;
            obj = new CatalogDbContext(options);
            InitializeTablesTest();
        }

        [TestMethod]
        public void InitializeTablesTest()
        {
            CatalogDbContext.InitializeTables(null);
            var o = new testClass(options);
            modelBuilder = o.RunOnModelCreating();
            CatalogDbContext.InitializeTables(modelBuilder);

        }
        //[TestMethod] public void CategoriesTest() => testHasDbSet<CategoryData>(modelBuilder);
        //[TestMethod] public void PartyTest() => testHasDbSet<PartyData>(modelBuilder);
        //[TestMethod] public void PriceTest() => testHasDbSet<PriceData>(modelBuilder);
        //[TestMethod] public void ProductTest() => testHasDbSet<ProductData>(modelBuilder);

        //[TestMethod] public void ProductsOfPartyTest() => testHasDbSet<ProductsOfPartyData>(modelBuilder, x => x.ProductId, x => x.PartyId);
        [TestMethod] public void UserProfilesTest() => testHasDbSet<UserProfileData>(modelBuilder);

        //[TestMethod] public void SubCategoriesTest() => testHasDbSet<SubCategoryData>(modelBuilder);
    }
}
