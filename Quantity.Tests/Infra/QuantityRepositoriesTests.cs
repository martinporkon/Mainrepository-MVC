using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Domain;
using Quantity.Domain.Common;
using Quantity.Infra;
using Sooduskorv_MVC.CommonTests.OverallTests;
using System;

namespace Quantity.Tests.Infra
{

    [TestClass] public class QuantityRepositoriesTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(QuantityRepositories);

        [DataTestMethod]
        [DataRow(typeof(IMeasuresRepository))]
        [DataRow(typeof(IUnitsRepository))]
        [DataRow(typeof(ISystemsOfUnitsRepository))]
        [DataRow(typeof(IUnitTermsRepository))]
        [DataRow(typeof(IUnitFactorsRepository))]
        [DataRow(typeof(IMeasureTermsRepository))]
        public void RegisterTest(Type t) => Assert.IsNotNull(GetRepository.Instance(t));

    }

}
