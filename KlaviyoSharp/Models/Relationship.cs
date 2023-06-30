
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class Relationship
{
    [JsonProperty("data")]
    public List<DataObject> Data { get; set; }
    [JsonProperty("links")]
    public Links Links { get; set; }
}