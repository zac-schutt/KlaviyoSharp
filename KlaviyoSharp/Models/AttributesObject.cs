using System.Collections.Generic;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public abstract class AttributesObject
{
    /// <summary>
    /// An object containing key/value pairs for any custom properties assigned to this object
    /// </summary>
    [JsonProperty("properties")]
    public Dictionary<string, string> Properties { get; set; }
}