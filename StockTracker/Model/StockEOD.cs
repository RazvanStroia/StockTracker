using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace StockTracker.Model
{
    public class StockEOD
    {
        public double? open { get; set; }
        public double? high { get; set; }
        public double? low { get; set; }
        public double? close { get; set; }
        public double? volume { get; set; }
        public double? adj_open { get; set; }
        public double? adj_high { get; set; }
        public double? adj_low { get; set; }
        public double? adj_close { get; set; }
        public double? adj_volume { get; set; }
        public double? split_factor { get; set; }
        public double? dividend { get; set; }
        public string name { get; set; }
        public string exchange_code { get; set; }
        public string asset_type { get; set; }
        public string price_currency { get; set; }
        public string symbol { get; set; }
        public string exchange { get; set; }
        public string date { get; set; }
    }
    [JsonSerializable(typeof(List<StockEOD>))]
    internal sealed partial class StockEODContext : JsonSerializerContext
    {

    }
}
