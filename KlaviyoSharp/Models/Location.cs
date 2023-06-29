using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class Location
{
    /// <summary>
    /// First line of street address
    /// </summary>
    [JsonProperty("address1")]
    public string Address1 { get; set; }
    /// <summary>
    /// First line of street address
    /// </summary>
    [JsonProperty("address2")]
    public string Address2 { get; set; }
    /// <summary>
    /// City name
    /// </summary>
    [JsonProperty("city")]
    public string City { get; set; }
    /// <summary>
    /// Country name
    /// </summary>
    [JsonProperty("country")]
    public string Country { get; set; }
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
    /// Region within a country, such as state or province
    /// </summary>
    [JsonProperty("region")]
    public string Region { get; set; }
    /// <summary>
    /// Zip code
    /// </summary>
    [JsonProperty("zip")]
    public string Zip { get; set; }
    /// <summary>
    /// Time zone name. We recommend using time zones from the IANA Time Zone Database.
    /// </summary>
    [JsonProperty("timezone")]
    public string Timezone { get; set; }
}