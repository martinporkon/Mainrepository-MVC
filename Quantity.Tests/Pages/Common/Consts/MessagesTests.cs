using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Pages.Common.Consts;

namespace Quantity.Tests.Pages.Common.Consts {

    [TestClass] public class MessagesTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(Messages);

        [TestMethod]
        public void PagesOfTest() =>
            Assert.AreEqual("Page {0} of {1}", Messages.PagesOf);

    }

}
