using Catalog.Data.Product;
using CommonData;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Tests.Data.Product
{
    [TestClass]
    public class PriceDataTests : SealedClassTests<CountryOfOriginData, DescribedEntityData>
    {

        [TestMethod] public void OfficialNameTest() => isNullableProperty<string>();
        [TestMethod] public void NativeNameTest() => isNullableProperty<string>();
        [TestMethod] public void NumericCodeTest() => isNullableProperty<string>();
        [TestMethod] public void IsIsoCOuntryTest() => isProperty<bool>();


    }
}
