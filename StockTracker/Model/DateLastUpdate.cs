using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace StockTracker.Model
{
    public class DateLastUpdate
    {
        public string date { get; set; }
        public int timezone_type { get; set; }
        public string timezone { get; set; }
    }
    [JsonSerializable(typeof(List<DateLastUpdate>))]
    internal sealed partial class DateLastUpdateContext : JsonSerializerContext
    {

    }
}
