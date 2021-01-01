using Aids.Constants;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests.AidsTests.ConstantsTests
{

    [TestClass]
    public class WordTests : BaseTests
    {

        [TestInitialize] public void TestInitialize() => type = typeof(Word);

        [TestMethod]
        public void UnspecifiedTest()
            => Assert.AreEqual("Unspecified", Word.UnSpecified);

        [TestMethod]
        public void ListTest()
            => Assert.AreEqual("List", Word.List);

        [TestMethod]
        public void NoneTest()
            => Assert.AreEqual("None", Word.None);

        [TestMethod]
        public void NullTest()
            => Assert.AreEqual("Null", Word.Null);

    }

}
