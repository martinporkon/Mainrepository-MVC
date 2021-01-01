using Abc.Pages.Common.Consts;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Quantity.Tests.Pages.Common.Consts {

    [TestClass] public class RulePagesNamesTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(RulePagesNames);
        [TestMethod] public void RuleSetsTest() => Assert.AreEqual("Rule Sets", RulePagesNames.RuleSets);
        [TestMethod] public void RulesTest() => Assert.AreEqual("Rules", RulePagesNames.Rules);
        [TestMethod] public void RuleElementsTest() => Assert.AreEqual("Rule Elements", RulePagesNames.RuleElements);
        [TestMethod] public void RulesMenuTest() => Assert.AreEqual("Rules", RulePagesNames.RulesMenu);
        [TestMethod] public void UsagesTest() => Assert.AreEqual("Rule Usages", RulePagesNames.Usages);
        [TestMethod] public void ContextsTest() => Assert.AreEqual("Rule Contexts", RulePagesNames.Contexts);
        [TestMethod] public void OverridesTest() => Assert.AreEqual("Rule Overrides", RulePagesNames.Overrides);

    }

}
