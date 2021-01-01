using System;
using Catalog.Data.Product;
using Catalog.Data.Services;
using CommonData;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Tests.Data.Product
{

    [TestClass]
    public class ProductInstanceDataTests : SealedClassTests<ProductInstanceData, DescribedEntityData>
    {

        [TestMethod] public void ProductTypeIdTest() => isNullableProperty<string>();
        [TestMethod] public void ProductKindTest() => isProperty<ProductKind>();
        [TestMethod] public void AmountTest() => isProperty<double>();
        [TestMethod] public void UnitIdTest() => isNullableProperty<string>();
        [TestMethod] public void PartyIdTest() => isNullableProperty<string>();
        
        [TestMethod] public void ScheduledFromTest() => isProperty<DateTime>();
        [TestMethod] public void ScheduledToTest() => isProperty<DateTime>();
        [TestMethod] public void DeliveredFromTest() => isProperty<DateTime>();
        [TestMethod] public void DeliveredToTest() => isProperty<DateTime>();
        [TestMethod] public void DeliveryStatusTest() => isProperty<DeliveryStatus>();

    }

}