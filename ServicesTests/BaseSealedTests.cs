using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ServicesTests
{

    public abstract class BaseSealedTests<TClass, TBaseClass> : BaseClassTests<TClass, TBaseClass> {


        [TestMethod] public void IsSealed() {
            Assert.IsTrue(type.IsSealed);
        }


    }

}
