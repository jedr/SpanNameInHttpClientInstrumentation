using OpenTelemetry;
using OpenTelemetry.Trace;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpanNameInHttpClientInstrumentation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var tracerProvider = Sdk
                .CreateTracerProviderBuilder()
                .AddHttpClientInstrumentation()
                .AddConsoleExporter()
                .Build();

            using var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("http://api.icndb.com/jokes/random");
        }
    }
}
