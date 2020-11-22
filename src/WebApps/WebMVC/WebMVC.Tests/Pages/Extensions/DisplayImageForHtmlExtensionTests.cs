using System.Collections.Generic;
using System.Text.Encodings.Web;
using CommonTests.OverallTests;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sooduskorv_MVC.Data.CommonData;
using SooduskorvWebMVC.Pages.Extensions;

namespace CoinCollectorProject.Tests.Pages.Extensions
{
    [TestClass]
    public class DisplayImageForHtmlExtensionTests : BaseTests
    {

        private const string alternateText = "no-image";

        [TestInitialize]
        public virtual void TestInitialize() => type = typeof(DisplayImageForHtmlExtension);
        private static List<object> GetString(IHtmlContent content)
        {
            using var writer = new System.IO.StringWriter();
            content.WriteTo(writer, HtmlEncoder.Default);
            return new List<object> { writer.ToString() };
        }

        [TestMethod]
        public void DisplayImageForTest()
        {
            var obj = new htmlHelperMock<ProductImageView>().DisplayImageFor(x => x.Id,
                new byte[123], alternateText, null);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod]
        public void HtmlStringsTest()
        {
            var expected = new List<string> {
                "<img alt=\"no-image\" src=\"data:image/jpg;base64, \"></img>"
            };
            var actual = DisplayImageForHtmlExtension.HtmlStrings(new htmlHelperMock<List<object>>(),
                new byte[0], alternateText, null);
            var result = GetString(new HtmlContentBuilder(actual));
            TestHtml.Strings(result, expected);
        }

    }

    public class ProductImageView : UniqueEntityData
    {
        public byte[] Content { get; set; }
        public string Name { get; set; }
    }
}