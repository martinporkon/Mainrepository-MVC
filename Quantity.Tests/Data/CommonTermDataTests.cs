﻿using CommonData;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;

namespace Quantity.Tests.Data {

    [TestClass] public class CommonTermDataTests : AbstractClassTests<CommonTermData, PeriodData> {

        private class testClass : CommonTermData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }

        [TestMethod] public void TermIdTest() => isNullableProperty(() => obj.TermId, x => obj.TermId = x);

        [TestMethod] public void MasterIdTest() => isNullableProperty(() => obj.MasterId, x => obj.MasterId = x);

        [TestMethod] public void PowerTest() => isProperty(() => obj.Power, x => obj.Power = x);

    }

}
