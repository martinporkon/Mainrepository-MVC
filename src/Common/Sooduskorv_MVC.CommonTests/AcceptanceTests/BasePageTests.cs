namespace WebMVC.Tests
{
    // TODO üldkasutatav klass erinevatele testidele. Arvatavasti tuleks see panna ka eraldi projekti.
    /*public abstract class BasePageTests : BaseSoftTests
    {
        protected IHtmlDocument htmlDocument; // See asi saab kätte terve html dokumendi nagu ta on nähtav veebilehes
        protected string pageHtml;

        [TestMethod] public void CanRespondToQueryTest() => sendRequest(pageUrl());
        protected abstract string pageUrl();

        protected IHtmlDocument sendRequest(string url)
        {
            var page = client.GetPage(url);
            Assert.AreEqual(HttpStatusCode.OK, page.StatusCode);
            Assert.AreEqual(HtmlTag.Header, page.GetHeader());
            pageHtml = page.GetString();// See asi saab kätte terve HTTPClient kasutuses oleva hetkese lehe ning teeb selle stringiks
            return HtmlDoc.GetAsync(page).GetAwaiter().GetResult();
        }
    }*/
}