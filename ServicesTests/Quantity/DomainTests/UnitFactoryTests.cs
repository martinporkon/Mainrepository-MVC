using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;

namespace ServicesTests.Quantity.DomainTests
{

    [TestClass]
    public class UnitFactoryTests : BaseTests
    {

        [TestInitialize]
        public void TestInitialize() => type = typeof(UnitFactory);
    
        [TestMethod]
        public void CreateTest() =>
            Assert.IsInstanceOfType(UnitFactory.Create(), typeof(FactoredUnit));

        [TestMethod]
        public void CreateFactoredTest() =>
            Assert.IsInstanceOfType(UnitFactory.Create(
                new UnitData{ UnitType = UnitType.Factored }), typeof(FactoredUnit));

        [TestMethod]
        public void CreateFunctionedTest() =>
            Assert.IsInstanceOfType(UnitFactory.Create(
                new UnitData { UnitType = UnitType.Functioned }), typeof(FunctionedUnit));
        [TestMethod]
        public void CreateDerivedTest() =>
            Assert.IsInstanceOfType(UnitFactory.Create(
                new UnitData { UnitType = UnitType.Derived }), typeof(DerivedUnit));
    }

}