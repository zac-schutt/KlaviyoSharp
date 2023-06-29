using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class Location : StreetAddress
{
    /// <summary>
    /// Latitude coordinate. We recommend providing a precision of four decimal places.
    /// </summary>
    [JsonProperty("latitude")]
    public decimal? Latitude { get; set; }
    /// <summary>
    /// Longitude coordinate. We recommend providing a precision of four decimal places.
    /// </summary>
    [JsonProperty("longitude")]
    public decimal? Longitude { get; set; }
    /// <summary>
    /// Time zone name. We recommend using time zones from the IANA Time Zone Database.
    /// </summary>
    [JsonProperty("timezone")]
    public string Timezone { get; set; }
}