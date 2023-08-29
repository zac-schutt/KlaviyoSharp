using Newtonsoft.Json;

namespace KlaviyoSharp.Models;
/// <summary>
/// Generic Klaviyo Object
/// </summary>
public class GenericObject{
    /// <summary>
    /// Generic constructor
    /// </summary>
    public GenericObject()
    {
    }

    /// <summary>
    /// Create a generic object with type and id
    /// </summary>
    /// <param name="type"></param>
    /// <param name="id"></param>
    public GenericObject(string type, string id)
    {
        this.Type = type;
        this.Id = id;
    }

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