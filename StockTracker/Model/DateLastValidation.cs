using System.Text.Json.Serialization;

namespace StockTracker.Model
{
    public class DateLastValidation
    {
        public string date { get; set; }
        public int timezone_type { get; set; }
        public string timezone { get; set; }
    }
    [JsonSerializable(typeof(List<DateLastValidation>))]
    internal sealed partial class DateLastValidationContext : JsonSerializerContext
    {

    }
}
