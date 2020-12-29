using System.Threading.Tasks;
using Aids.Random;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Domain.Common;

namespace ServicesTests.Quantity.DomainTests
{

    [TestClass]
    public class UnitAttributeTests : AbstractClassTests<UnitAttribute<UnitFactorData>, Entity<UnitFactorData>>
    {
        private class testClass : UnitAttribute<UnitFactorData>
        {

            public testClass(UnitFactorData d) : base(d) { }

        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass(GetRandom.Object<UnitFactorData>());
        }

        [TestMethod]
        public void SystemOfUnitsIdTest()
            => isReadOnlyProperty(obj, nameof(obj.SystemOfUnitsId), obj.Data.SystemOfUnitsId);

        [TestMethod]
        public async Task SystemOfUnitsTest()
        {
            var d = GetRandom.Object<SystemOfUnitsData>();
            d.Id = obj.SystemOfUnitsId;
            await GetRepository.Instance<ISystemsOfUnitsRepository>().Add(new SystemOfUnits(d));
            arePropertiesEqual(d, obj.SystemOfUnits.Data);
        }
        [TestMethod]
        public void UnitIdTest()
            => isReadOnlyProperty(obj, nameof(obj.UnitId), obj.Data.UnitId);

        [TestMethod]
        public async Task UnitTest()
        {
            var d = GetRandom.Object<UnitData>();
            d.UnitType = UnitType.Factored;
            d.Id = obj.UnitId;
            await GetRepository.Instance<IUnitsRepository>().Add(new FactoredUnit(d));

            arePropertiesEqual(d, obj.Unit.Data);
        }



    }

}