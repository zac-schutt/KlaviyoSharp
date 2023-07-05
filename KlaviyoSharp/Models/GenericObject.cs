using Newtonsoft.Json;

namespace KlaviyoSharp.Models;
/// <summary>
/// Generic Klaviyo Object
/// </summary>
public class GenericObject{
    /// <summary>
    /// Type of object
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; }
    /// <summary>
    /// Internal ID of object
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }
}