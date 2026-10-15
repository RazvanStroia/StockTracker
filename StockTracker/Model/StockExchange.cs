using System.Text.Json.Serialization;

namespace StockTracker.Model
{
    public class StockExchange
    {
        public string name { get; set; }
        public string acronym { get; set; }
        public string mic { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
        public string city { get; set; }
        public string website { get; set; }
        public string operating_mic { get; set; }
        public string oprt_sgmt { get; set; }
        public string legal_entity_name { get; set; }
        public string exchange_lei { get; set; }
        public string market_category_code { get; set; }
        public string exchange_status { get; set; }
        public DateCreation date_creation { get; set; }
        public DateLastUpdate date_last_update { get; set; }
        public DateLastValidation date_last_validation { get; set; }
        public DateExpiry date_expiry { get; set; }
        public string comments { get; set; }
    }
    [JsonSerializable(typeof(List<StockExchange>))]
    internal sealed partial class StockExchangeContext : JsonSerializerContext
    {

    }
}
