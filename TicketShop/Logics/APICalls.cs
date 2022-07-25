using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShop.Objects;

namespace TicketShop.Logics
{
    public class APICalls
    {
        public static CurrencyConversionResult GetCurrencyConversionAPI(string to, decimal amount)
        {
            string apiUrl = "https://api.apilayer.com/currency_data/convert?to=" + to + "&from=USD&amount=" + Functions.APIUrlCustomization(amount);

            var client = new RestClient(apiUrl)
            {
                Timeout = -1
            };

            var request = new RestRequest(Method.GET);
            request.AddHeader("apikey", "anXgRX3KuzAJjz6syIGXgPVohL0y5wsN");

            IRestResponse response = client.Execute(request);
            var result = JsonConvert.DeserializeObject<CurrencyConversionResult>(response.Content);
            return result;
        }
    }
}
