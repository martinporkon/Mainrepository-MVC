using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Domain.Common;

namespace ServicesTests.Quantity.DomainTests
{
    [TestClass]
    public class SystemOfUnitsTests: SealedTests<SystemOfUnits, DefinedEntity<SystemOfUnitsData>>
    {
    }
}