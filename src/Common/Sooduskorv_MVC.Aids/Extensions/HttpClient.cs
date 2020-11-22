using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sooduskorv_MVC.Aids.HTTP;
using Sooduskorv_MVC.Aids.Methods;

namespace Sooduskorv_MVC.Aids.Extensions
{
    public static class HttpClient// TODO singleton pattern Dispose
    {
        public static async Task<T> ReadAsStreamAsync<T>(this HttpResponseMessage responseMessage) where T : class
        {
            if (!responseMessage.IsSuccessStatusCode || responseMessage.StatusCode != HttpStatusCode.Created)
            {
                StatusCodes.Handle(responseMessage.StatusCode, responseMessage);
                /*return*/
            }

            // TODO dispose
            var result = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);

            using var streamReader = new StreamReader(result);
            using var jsonTextReader = new JsonTextReader(streamReader);
            var jsonSerializer = new JsonSerializer();

            return Safe.Run(jsonSerializer.Deserialize<T>(jsonTextReader));
        }
    }
}