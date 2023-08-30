using System.Net.Http;
using Newtonsoft.Json;

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
    /// <summary>
    /// Converts a HttpResponseMessage to a KlaviyoError
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    public static KlaviyoError FromHttpResponse(HttpResponseMessage response)
    {
        return JsonConvert.DeserializeObject<KlaviyoError>(
            response.Content.ReadAsStringAsync().Result,
            Infrastructure.JsonContent.KlaviyoJsonSerializerSettings);
    }
}

/// <summary>
/// Details of the error returned from the Klaviyo API
/// </summary>
public class KlaviyoErrorDetails
{
    /// <summary>
    /// ID of the error
    /// </summary>
    public string Id { get; set; }
    /// <summary>
    /// Code name of the error
    /// </summary>
    public string Code { get; set; }
    /// <summary>
    /// Details about the cause of the error
    /// </summary>
    public string Detail { get; set; }
    /// <summary>
    /// Error title
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// Source of the error in the request
    /// </summary>
    public KlaviyoErrorSource Source { get; set; }
}

/// <summary>
/// Source of the error in the request
/// </summary>
public class KlaviyoErrorSource
{
    /// <summary>
    /// Pointer to the error in the request body
    /// </summary>
    public string Pointer { get; set; }
    /// <summary>
    /// Parameter in the request that caused the error
    /// </summary>
    public string Parameter { get; set; }
}