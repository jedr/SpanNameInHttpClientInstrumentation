using System;
using System.Diagnostics;
using System.Net.Http;
using OpenTelemetry.Trace;

namespace SpanNameInHttpClientInstrumentation
{
    public class HttpClientSpanNameEnrichmentProcessor : ActivityProcessor
    {
        public override void OnStart(Activity activity)
        {
            var httpRequest = activity.GetCustomProperty("OTel.HttpHandler.Request") as HttpRequestMessage;
            if (httpRequest != null)
            {
                activity.DisplayName = httpRequest.RequestUri.AbsolutePath;
                Console.WriteLine($"✅ Found request in OnStart, updating span name to {httpRequest.RequestUri.AbsolutePath}");
            }
            else
            {
                Console.WriteLine($"❌ Request not found in OnStart");
            }
        }

        public override void OnEnd(Activity activity)
        {
            var httpRequest = activity.GetCustomProperty("OTel.HttpHandler.Request") as HttpRequestMessage;
            if (httpRequest != null)
            {
                activity.DisplayName = httpRequest.RequestUri.AbsolutePath;
                Console.WriteLine($"✅ Found request in OnEnd, updating span name to {httpRequest.RequestUri.AbsolutePath}");
            }
            else
            {
                Console.WriteLine($"❌ Request not found in OnEnd");
            }
        }
    }
}
