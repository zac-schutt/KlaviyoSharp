using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class StreetAddress
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
    /// Region within a country, such as state or province
    /// </summary>
    [JsonProperty("region")]
    public string Region { get; set; }
    /// <summary>
    /// Zip code
    /// </summary>
    [JsonProperty("zip")]
    public string Zip { get; set; }
}