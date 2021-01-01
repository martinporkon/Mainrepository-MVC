using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Domain.Common;

namespace Quantity.Tests.Domain
{
    [TestClass] public class UnitTermTests : SealedClassTests<UnitTerm, Entity<UnitTermData>> { }
}
