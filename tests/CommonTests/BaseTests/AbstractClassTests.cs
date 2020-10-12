using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests.BaseTests
{
    public abstract class AbstractClassTests<TClass, TBaseClass> : BaseClassTests<TClass, TBaseClass>
    {
        [TestMethod]
        public void IsAbstract() => Assert.IsTrue(type.IsAbstract);
    }
}