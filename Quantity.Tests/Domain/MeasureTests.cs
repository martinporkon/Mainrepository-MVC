using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Domain.Common;

namespace Abc.Tests.Domain.Quantity
{
    [TestClass]
    public class MeasureTests : SealedClassTests<Measure, Entity<MeasureData>>
    {
    }
}
