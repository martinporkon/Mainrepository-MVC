using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Html.Dom;
using AngleSharp.Io;

namespace WebMVC.Tests
{
    public static class HtmlDoc
    {

        public static async Task<IHtmlDocument> GetAsync(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            var document = await BrowsingContext.New()
                .OpenAsync(responseFactory, CancellationToken.None);

            return (IHtmlDocument)document;

            void responseFactory(VirtualResponse htmlResponse)
            {
                htmlResponse
                    .Address(response.RequestMessage.RequestUri)
                    .Status(response.StatusCode);

                mapHeaders(response.Headers);
                mapHeaders(response.Content.Headers);

                htmlResponse.Content(content);

                void mapHeaders(HttpHeaders headers)
                {
                    foreach (var header in headers)
                    {
                        foreach (var value in header.Value) { htmlResponse.Header(header.Key, value); }
                    }
                }
            }
        }

        public static IHtmlAnchorElement FindAnchorElement(this IHtmlDocument doc, string tag)// TODO võib tekkida exception
            => doc.FindElement(tag) as IHtmlAnchorElement;

        public static IHtmlElement FindElement(this IHtmlDocument doc, string tag)
            => (IHtmlElement)doc.QuerySelector(tag);
    }
}