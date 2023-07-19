using Newtonsoft.Json;
/// <summary>
/// UTM Params
/// </summary>
public class UTMParams
{
    /// <summary>
    /// Name of the UTM param
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
    /// <summary>
    /// Value of the UTM param. Can be templated data.
    /// </summary>
    [JsonProperty("value")]
    public string Value { get; set; }
}