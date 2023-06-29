using Newtonsoft.Json;

namespace KlaviyoSharp.Infrastructure;

/// <summary>
/// A wrapper for the data object in a request body
/// </summary>
public class RequestBody
{
    /// <summary>
    /// The data object in a request body
    /// </summary>
    [JsonProperty("data")]
    public Models.DataObject Data { get; set; }
    public RequestBody(Models.DataObject dataObject)
    {
        Data = dataObject;
    }
}