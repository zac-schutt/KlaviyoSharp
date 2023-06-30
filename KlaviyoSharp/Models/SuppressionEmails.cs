using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class SuppressionEmails
{
    /// <summary>
    /// The email of the profile to suppress / unsuppress.
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; set; }
}