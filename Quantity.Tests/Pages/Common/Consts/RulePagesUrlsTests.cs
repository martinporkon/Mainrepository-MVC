using Abc.Pages.Common.Consts;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Quantity.Tests.Pages.Common.Consts {

    [TestClass]
    public class RulePagesUrlsTests : BaseTests
    {

        [TestInitialize] public void TestInitialize() => type = typeof(RulePagesUrls);
        [TestMethod] public void RuleSetsTest() => Assert.AreEqual("/Rules/Sets", RulePagesUrls.RuleSets) ;
        [TestMethod] public void RulesTest() => Assert.AreEqual("/Rules/Rules", RulePagesUrls.Rules);
        [TestMethod] public void RuleElementsTest() => Assert.AreEqual("/Rules/Elements", RulePagesUrls.RuleElements);
        [TestMethod] public void UsagesTest() => Assert.AreEqual("/Rules/Usages", RulePagesUrls.Usages);
        [TestMethod] public void ContextsTest() => Assert.AreEqual("/Rules/Contexts", RulePagesUrls.Contexts);
        [TestMethod] public void OverridesTest() => Assert.AreEqual("/Rules/Overrides", RulePagesUrls.Overrides);


    }

}