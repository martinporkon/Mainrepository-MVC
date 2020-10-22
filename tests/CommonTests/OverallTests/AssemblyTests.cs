using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests.OverallTests
{
    public class AssemblyTests : BaseAssemblyTests
    {
        //TODO õiged namespaced panna
        [TestMethod] public void IsAddressesTested() => isAllTested(assembly, nameSpace("Addresses"));
        [TestMethod] public void IsAddressOfCustomerTested() => isAllTested(assembly, nameSpace("AddressOfCustomer"));
        [TestMethod] public void IsAddressOfPartyTested() => isAllTested(assembly, nameSpace("AddressOfParty"));
        [TestMethod] public void IsBasketOfProductsTested() => isAllTested(assembly, nameSpace("BasketOfProducts"));
        [TestMethod] public void IsBasketsTested() => isAllTested(assembly, nameSpace("Baskets"));
        [TestMethod] public void IsCategoriesTested() => isAllTested(assembly, nameSpace("Categories"));
        [TestMethod] public void IsCommonTested() => isAllTested(assembly, nameSpace("Common"));
        [TestMethod] public void IsCustomersTested() => isAllTested(assembly, nameSpace("Customers"));
        [TestMethod] public void IsOrdersTested() => isAllTested(assembly, nameSpace("Orders"));
        [TestMethod] public void IsPartiesTested() => isAllTested(assembly, nameSpace("Parties"));
        [TestMethod] public void IsPricesTested() => isAllTested(assembly, nameSpace("Prices"));
        [TestMethod] public void IsProductsOfPartyTested() => isAllTested(assembly, nameSpace("ProductsOfParty"));
        [TestMethod] public void IsProductsTested() => isAllTested(assembly, nameSpace("Products"));
        [TestMethod] public void IsShipMethodOfPartyTested() => isAllTested(assembly, nameSpace("ShipMethodOfParty"));
        [TestMethod] public void IsShipMethodsTested() => isAllTested(assembly, nameSpace("ShipMethods"));
        [TestMethod] public void IsSubCategoriesTested() => isAllTested(assembly, nameSpace("SubCategories"));
    }
}
