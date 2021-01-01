using Aids.Reflection;
using Catalog.Data.Product;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Data.Products
{

    [TestClass] public class ProductKindTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(ProductKind);

        [TestMethod] public void CountTest()
            => Assert.AreEqual(4, GetEnum.Count<ProductKind>());

        [TestMethod]
        public void UnspecifiedTest() =>
            Assert.AreEqual(0, (int)ProductKind.Unspecified);

        [TestMethod]
        public void ProductTest() =>
            Assert.AreEqual(1, (int)ProductKind.Product);

        [TestMethod]
        public void MeasuredProductTest() =>
            Assert.AreEqual(2, (int)ProductKind.MeasuredProduct);

        [TestMethod]
        public void ServiceTest() =>
            Assert.AreEqual(5, (int)ProductKind.Service);

        

    }

}