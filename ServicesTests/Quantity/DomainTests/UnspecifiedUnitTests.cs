using Aids.Random;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Domain;
using Quantity.Domain.Common;

namespace ServicesTests.Quantity.DomainTests
{

    [TestClass] public class UnspecifiedUnitTests : SealedTests<UnspecifiedUnit, Unit> {

        [TestMethod] public void ToBaseTest() =>
            Assert.AreEqual(BaseEntity.UnspecifiedDouble, obj.ToBase(GetRandom.Double()));

        [TestMethod]
        public void FromBaseTest() =>
            Assert.AreEqual(BaseEntity.UnspecifiedDouble, obj.FromBase(GetRandom.Double()));
    }

}