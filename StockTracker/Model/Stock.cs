using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace StockTracker.Model
{
    public class Stock
    {
        public string name { get; set; }
        public string ticker { get; set; }
        public bool has_intraday { get; set; }
        public bool has_eod { get; set; }
        public StockExchange stock_exchange { get; set; }
        public string image { get; set; }
        public double? open {  get; set; }
    }
    [JsonSerializable(typeof(List<Stock>))]
    internal sealed partial class StockContext : JsonSerializerContext
    {

    }
}
