using CommonTests.InfraTests;
using Quantity.Data;
using Quantity.Infra;

namespace Quantity.Tests.Infra {

    [TestClass] public class QuantityDbContextTests : DbContextTests<QuantityDbContext, DbContext> {

        private class testClass : QuantityDbContext {

            public testClass(DbContextOptions<QuantityDbContext> o) : base(o) { }

            public ModelBuilder RunOnModelCreating() {
                var set = new ConventionSet();
                var mb = new ModelBuilder(set);
                OnModelCreating(mb);

                return mb;
            }

        }


        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            options = new DbContextOptionsBuilder<QuantityDbContext>().UseInMemoryDatabase("TestDb").Options;
            obj = new QuantityDbContext(options);
        }

        [TestMethod] public void InitializeTablesTest() {
            QuantityDbContext.InitializeTables(null);
            var o = new testClass(options);
            var builder = o.RunOnModelCreating();
            QuantityDbContext.InitializeTables(builder);
            testEntity<SystemOfUnitsData>(builder);
            testEntity<MeasureTermData>(builder, x => x.TermId, x => x.MasterId);
            testEntity<MeasureData>(builder);
            testEntity<UnitData>(builder);
            testEntity<UnitTermData>(builder, x => x.TermId, x => x.MasterId);
            testEntity<UnitFactorData>(builder, x =>x.UnitId, x=> x.SystemOfUnitsId);
            testEntity<UnitRulesData>(builder, x => x.UnitId, x => x.SystemOfUnitsId);
        }

        [TestMethod] public void MeasuresTest() =>
            isNullableProperty(obj, nameof(obj.Measures), typeof(DbSet<MeasureData>));

        [TestMethod] public void UnitsTest() => isNullableProperty(obj, nameof(obj.Units), typeof(DbSet<UnitData>));

        [TestMethod] public void SystemsOfUnitsTest() =>
            isNullableProperty(obj, nameof(obj.SystemsOfUnits), typeof(DbSet<SystemOfUnitsData>));

        [TestMethod] public void UnitFactorsTest() =>
            isNullableProperty(obj, nameof(obj.UnitFactors), typeof(DbSet<UnitFactorData>));

        [TestMethod]
        public void UnitRulesTest() =>
            isNullableProperty(obj, nameof(obj.UnitRules), typeof(DbSet<UnitRulesData>));

        [TestMethod] public void UnitTermsTest() =>
            isNullableProperty(obj, nameof(obj.UnitTerms), typeof(DbSet<UnitTermData>));

        [TestMethod] public void MeasureTermsTest() =>
            isNullableProperty(obj, nameof(obj.MeasureTerms), typeof(DbSet<MeasureTermData>));

    }

}
