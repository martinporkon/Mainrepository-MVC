using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Sooduskorv_MVC.Aids.Reflection;
using Sooduskorv_MVC.CommonTests.OverallTests;

namespace Quantity.Tests.Data
{
    [TestClass]
    public class MeasureTypeTests : BaseTests
    {

        [TestInitialize] public void TestInitialize() => type = typeof(MeasureType);

        [TestMethod]
        public void CountTest()
            => Assert.AreEqual(4, GetEnum.Count<MeasureType>());

        [TestMethod]
        public void UnspecifiedTest() =>
            Assert.AreEqual(0, (int)MeasureType.Unspecified);

        [TestMethod]
        public void BaseTest() =>
            Assert.AreEqual(1, (int)MeasureType.Base);

        [TestMethod]
        public void DerivedTest() =>
            Assert.AreEqual(2, (int)MeasureType.Derived);


        [TestMethod]
        public void ErrorTest() =>
            Assert.AreEqual(9, (int)MeasureType.Error);

    }

}