using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;

namespace ServicesTests.Quantity.DomainTests
{

    [TestClass] public class UnitFactorTests : SealedTests<UnitFactor, UnitAttribute<UnitFactorData>> {

        [TestMethod] public void FactorTest()
            => isReadOnlyProperty(obj, nameof(obj.Factor), obj.Data.Factor);

    }

}