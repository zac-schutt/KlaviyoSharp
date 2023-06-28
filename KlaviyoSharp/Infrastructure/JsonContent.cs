using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace KlaviyoSharp.Infrastructure;
public class JsonContent : ByteArrayContent
{
    private object Data { get; set; }

    public JsonContent(object data) : base(ToBytes(data))
    {
        Data = data;
        Headers.ContentType = new MediaTypeHeaderValue("application/json");
    }

    private static byte[] ToBytes(object data)
    {
        var rawData = JsonSerializer.Serialize(data);

        return Encoding.UTF8.GetBytes(rawData);
    }

    public JsonContent Clone()
    {
        return new JsonContent(Data);
    }
}