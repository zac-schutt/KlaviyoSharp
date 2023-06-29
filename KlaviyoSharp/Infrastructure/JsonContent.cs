using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace KlaviyoSharp.Infrastructure;
/// <summary>
/// A custom HttpContent for JSON data
/// </summary>
public class JsonContent : ByteArrayContent
{
    private RequestBody Data { get; set; }
    /// <summary>
    /// Creates a new JsonContent with the given RequestBody data
    /// </summary>
    /// <param name="data"></param>
    public JsonContent(RequestBody data) : base(ToBytes(data))
    {
        Data = data;
        Headers.ContentType = new MediaTypeHeaderValue("application/json");
    }
    /// <summary>
    /// Convert the RequestBody data to a byte array
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private static byte[] ToBytes(RequestBody data)
    {
        string rawData = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            Converters = new List<JsonConverter> {
                new DateTimeJsonConverter(),
                new DateTimeNullableJsonConverter()
            }
        });
        return Encoding.UTF8.GetBytes(rawData);
    }
    /// <summary>
    /// Clones the JsonContent
    /// </summary>
    /// <returns></returns>
    public JsonContent Clone()
    {
        return new JsonContent(Data);
    }
}
