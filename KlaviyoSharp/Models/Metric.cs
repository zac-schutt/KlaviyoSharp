using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class Metric
{
    /// <summary>
    /// Name of the event. Must be less than 128 characters.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
    /// <summary>
    /// This is for advanced usage. For api requests, this should use the default, which is set to api.
    /// </summary>
    [JsonProperty("service")]
    public string Service { get; set; } = "api";
}