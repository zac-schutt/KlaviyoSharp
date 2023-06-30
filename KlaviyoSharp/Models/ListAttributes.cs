using System;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;


public class ListAttributes : AttributesObject
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("created")]
    public DateTime? Created { get; set; }
    [JsonProperty("updated")]
    public DateTime? Updated { get; set; }
}