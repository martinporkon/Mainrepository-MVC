using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Facade.Common;
using Sooduskorv_MVC.Aids.Random;
using Sooduskorv_MVC.CommonTests.OverallTests;

namespace Quantity.Tests.Facade.Common
{

    [TestClass] public class UniqueEntityViewTests : AbstractClassTests<UniqueEntityView, PeriodView> {

        private class testClass : UniqueEntityView { }

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = GetRandom.Object<testClass>();
        }

        [TestMethod] public void IdTest() => isNullableProperty(() => obj.Id, x => obj.Id = x);

        [TestMethod] public void GetIdTest() => Assert.AreEqual(obj.Id, obj.GetId());

    }

}