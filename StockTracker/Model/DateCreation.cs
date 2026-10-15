using System.Text.Json.Serialization;

namespace StockTracker.Model
{
    public class DateCreation
    {
        public string date { get; set; }
        public int timezone_type { get; set; }
        public string timezone { get; set; }
    }
    [JsonSerializable(typeof(List<DateCreation>))]
    internal sealed partial class DateCreationContext : JsonSerializerContext
    {

    }
}
