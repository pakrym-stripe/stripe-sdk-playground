using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stripe;
using Stripe.TestHelpers.Terminal;

namespace stripe_dotnet_playground
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient(new VersionHttpClientHandler(System.IO.File.ReadAllText("../api_version")));
            var service = new ReaderService(new StripeClient(
                apiKey: System.IO.File.ReadAllText("../api_key"),
                httpClient: new SystemNetHttpClient(httpClient)));

            service.SimulatePayment("tmr_EihpMAqu6AYhxl");
        }
        
        // WORKAROUND TO SET THE CLIENT VERSION
        private class VersionHttpClientHandler: HttpClientHandler
        {
            private string _version; 
            public VersionHttpClientHandler(string version)
            {
                this._version = version;
            }
            protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                request.Headers.Remove("Stripe-Version");
                request.Headers.TryAddWithoutValidation("Stripe-Version", _version);
                return base.Send(request, cancellationToken);
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                request.Headers.Remove("Stripe-Version");
                request.Headers.TryAddWithoutValidation("Stripe-Version", _version);
                return base.SendAsync(request, cancellationToken);
            }
        }
    }
}
