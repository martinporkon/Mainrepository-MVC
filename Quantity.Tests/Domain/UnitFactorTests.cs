using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Domain.Common;
using Sooduskorv_MVC.CommonTests.OverallTests;

namespace Quantity.Tests.Domain
{
    [TestClass] public class UnitFactorTests : SealedClassTests<UnitFactor, Entity<UnitFactorData>> { }
}
