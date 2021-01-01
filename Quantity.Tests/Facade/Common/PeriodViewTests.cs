using System;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Facade.Common;

namespace Quantity.Tests.Facade.Common {

    [TestClass] public class PeriodViewTests : AbstractClassTests<PeriodView, object> {

        private class testClass : PeriodView {

            public override string GetId() => string.Empty;

        }

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = new testClass();
        }

        //[TestMethod] public void FromTest() => isNullableProperty<DateTime?>();

        //[TestMethod] public void ToTest() => isNullableProperty<DateTime?>();

        //[TestMethod] public void GetIdTest() => isAbstractMethod(nameof(obj.GetId));

    }

}