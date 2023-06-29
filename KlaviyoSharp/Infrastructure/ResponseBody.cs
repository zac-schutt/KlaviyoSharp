using KlaviyoSharp.Models;
using Newtonsoft.Json;

namespace KlaviyoSharp.Infrastructure;

public class ResponseBody<T>
{
    [JsonProperty("data")]
    public T Data { get; set; }
    [JsonProperty("links")]
    public Links Links { get; set; }
}