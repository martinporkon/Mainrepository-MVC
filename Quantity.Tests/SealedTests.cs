using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Quantity.Tests
{

    public abstract class SealedTests<TClass, TBaseClass> : ClassTests<TClass, TBaseClass> where TClass : class {


        [TestMethod] public void IsSealed() {
            Assert.IsTrue(type.IsSealed);
        }

    }

}