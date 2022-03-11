using System;
using Stripe;

namespace stripe_dotnet_playground
{
    class Program
    {
        static void Main(string[] args)
        {
            StripeConfiguration.ApiKey = System.IO.File.ReadAllText("../api_key");

            var options = new ChargeListOptions { Limit = 3 };
            var service = new ChargeService();
            foreach (var charge in service.List(options))
            {
                Console.WriteLine(charge);
            }
        }
    }
}
