using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebMVC.Bff.HttpAggregator.Gateway.Middleware.HealthChecks
{
    public class JsonWriteResponseExtensions
    {
        private static Task WriteResponse(HttpContext context, HealthReport result)
        {
            context.Response.ContentType = "application/json; charset=utf-8";

            var options = new JsonWriterOptions
            {
                Indented = true
            };

            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream, options))
            {
                writer.WriteStartObject();
                writer.WriteString("status", result.Status.ToString());
                writer.WriteStartObject("results");
                foreach (var (s, healthReportEntry) in result.Entries)
                {
                    writer.WriteStartObject(s);
                    writer.WriteString("status", healthReportEntry.Status.ToString());
                    writer.WriteString("description", healthReportEntry.Description);
                    writer.WriteStartObject("data");
                    foreach (var (key, value) in healthReportEntry.Data)
                    {
                        writer.WritePropertyName(key);
                        JsonSerializer.Serialize(
                            writer, value, value?.GetType() ?? typeof(object));
                    }

                    WriteJsonWriterEndObject(writer, 2);
                }
                WriteJsonWriterEndObject(writer, 2);
            }

            var json = Encoding.UTF8.GetString(stream.ToArray());

            return context.Response.WriteAsync(json);
        }

        private static Task WriteResponseNewtonSoft(HttpContext context, HealthReport result)
        {
            context.Response.ContentType = "application/json";

            var json = new JObject(
                new JProperty("status", result.Status.ToString()),
                new JProperty("results", new JObject(result.Entries.Select(pair =>
                    new JProperty(pair.Key, new JObject(
                        new JProperty("status", pair.Value.Status.ToString()),
                        new JProperty("description", pair.Value.Description),
                        new JProperty("data", new JObject(pair.Value.Data.Select(
                            p => new JProperty(p.Key, p.Value))))))))));

            return context.Response.WriteAsync(
                json.ToString(Formatting.Indented));
        }

        private static void WriteJsonWriterEndObject(Utf8JsonWriter writer, int number = 0)
        {
            if (number > 2) return;
            for (var i = 0; i <= number; i++)
            {
                writer.WriteEndObject();
            }
        }
    }
}