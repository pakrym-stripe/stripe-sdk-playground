using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Stripe;
using Stripe.TestHelpers.Terminal;

namespace stripe_dotnet_playground
{
    class Program
    {
        static async Task Main(string[] args)
        {
            StripeConfiguration.ApiKey = System.IO.File.ReadAllText("../api_key");
            var httpClient = new HttpClient(new VersionHttpClientHandler(System.IO.File.ReadAllText("../api_version")));
            var service = new PriceService(new StripeClient(
                apiKey: System.IO.File.ReadAllText("../api_key"),
                httpClient: new SystemNetHttpClient(httpClient)));

            var currencyOptions = new Dictionary<string, PriceCurrencyOptionsOptions>()
            {
                {
                    "uah",
                    new PriceCurrencyOptionsOptions()
                    {
                        UnitAmount = 200
                    }
                }
            };
            var price = await service.CreateAsync(new PriceCreateOptions()
            {
                UnitAmount = 100,
                Currency = "usd",
                Product = "prod_M0Lpw1Epw64v4J",
                CurrencyOptions = currencyOptions
            });
            
            Console.WriteLine(await service.GetAsync(price.Id, new PriceGetOptions()
            {
                Expand = new List<string>() {"currency_options"}
            }));
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
