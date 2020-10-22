using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests.OverallTests
{
    public abstract class SealedClassTests<TClass, TBaseClass> : ClassTests<TClass, TBaseClass> where TClass : new()
    {
        [TestMethod]
        public void IsSealed() => Assert.IsTrue(type.IsSealed);
    }
}