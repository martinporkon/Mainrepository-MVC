using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sooduskorv_MVC.CommonTests.OverallTests
{
    public abstract class ClassTests<TClass, TBaseClass> : BaseClassTests<TClass, TBaseClass> where TClass : new()
    {

        [TestInitialize]
        public override void TestInitialize()
        {
            obj = new TClass();
            type = obj.GetType();
        }
        [TestMethod]
        public void CanCreateTest()
        {
            TestInitialize();
            Assert.IsNotNull(obj);
        }
    }
}