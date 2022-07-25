using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketShop.Objects
{
    public class CurrencyConversionResult
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("historical")]
        public bool Historical { get; set; }

        [JsonProperty("info")]
        public Info Info { get; set; }

        [JsonProperty("query")]
        public Query Query { get; set; }

        [JsonProperty("result")]
        public decimal Result { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
    }

    public class Info
    {
        [JsonProperty("quote")]
        public double Quote { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
    public class Query
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }
    }
}
