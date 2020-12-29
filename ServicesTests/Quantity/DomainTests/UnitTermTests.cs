using Aids.Random;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Domain.Common;
using Quantity.Infra;

namespace ServicesTests.Quantity.DomainTests
{

    [TestClass]
    public class UnitTermTests : SealedTests<UnitTerm, Term<UnitTermData>>
    {

        private UnitsRepository units;
        private QuantityDbContext db;

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = new UnitTerm(GetRandom.Object<UnitTermData>());
            units = GetRepository.Instance<IUnitsRepository>() as UnitsRepository;
            db = units?.db as QuantityDbContext;
        }

        public override void TestCleanup() {
            removeAll(db?.Units, db);
            units = null;
            db = null;
            base.TestCleanup();
        }

        [TestMethod]
        public void MasterUnitIdTest()
            => isReadOnlyProperty(obj, nameof(obj.MasterUnitId), obj.Data.MasterId);

        [TestMethod]
        public void TermUnitIdTest()
            => isReadOnlyProperty(obj, nameof(obj.TermUnitId), obj.Data.TermId);

        [TestMethod]
        public void MasterUnitTest()
        {
            var d = GetRandom.Object<UnitData>();
            d.UnitType = UnitType.Derived;
            d.Id = obj.MasterUnitId;
            units.Add(new DerivedUnit(d)).GetAwaiter();
            arePropertiesEqual(d, obj.MasterUnit.Data);
        }

        [TestMethod]
        public void TermUnitTest()
        {
            var d = GetRandom.Object<UnitData>();
            d.UnitType = UnitType.Factored;
            d.Id = obj.TermUnitId;
            units.Add(new FactoredUnit(d)).GetAwaiter();
            arePropertiesEqual(d, obj.TermUnit.Data);
        }

        [TestMethod]
        public void FormulaTest()
        {
            var d = GetRandom.Object<UnitData>();
            d.UnitType = UnitType.Factored;
            d.Id = obj.TermUnitId;
            units.Add(new FactoredUnit(d)).GetAwaiter();

            if (obj.Power != 1)
            {
                Assert.AreEqual($"{d.Code}^{obj.Power}", obj.Formula());
                Assert.AreEqual($"{d.Name}^{obj.Power}", obj.Formula(true));
            }
            else
            {
                Assert.AreEqual($"{d.Code}", obj.Formula());
                Assert.AreEqual($"{d.Name}", obj.Formula(true));
            }
        }

    }

}