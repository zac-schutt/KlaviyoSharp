using System.Net.Http;
using System.Text.Json;

namespace KlaviyoSharp.Models;

/// <summary>
/// Error Returned from the Klaviyo API
/// </summary>
public class KlaviyoError
{
    /// <summary>
    /// List of errors returned
    /// </summary>
    public KlaviyoErrorDetails[] Errors { get; set; }
    public static KlaviyoError FromHttpResponse(HttpResponseMessage response)
    {
        return JsonSerializer.Deserialize<KlaviyoError>(response.Content.ReadAsStringAsync().Result);
    }
}