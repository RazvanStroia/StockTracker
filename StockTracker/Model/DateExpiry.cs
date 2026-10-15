using System.Text.Json.Serialization;

namespace StockTracker.Model
{
    public class DateExpiry
    {
        public string date { get; set; }
        public int timezone_type { get; set; }
        public string timezone { get; set; }
    }
    [JsonSerializable(typeof(List<DateExpiry>))]
    internal sealed partial class DateExpiryContext : JsonSerializerContext
    {

    }
}
