using CommonTests.OverallTests;
using Quantity.Domain;
using Quantity.Domain.Common;
using Quantity.Infra;

namespace Quantity.Tests.Infra {

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
