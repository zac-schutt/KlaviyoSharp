using Newtonsoft.Json;

namespace KlaviyoSharp.Models;
/// <summary>
/// Contact information for a account
/// </summary>
public class ContactInformation
{
    /// <summary>
    /// This field is used to auto-populate the default sender name on flow and campaign emails.
    /// </summary>
    [JsonProperty("default_sender_name")]
    public string DefaultSenderName { get; set; }
    /// <summary>
    /// This field is used to auto-populate the default sender email address on flow and campaign emails.
    /// </summary>
    [JsonProperty("default_sender_email")]
    public string DefaultSenderEmail { get; set; }
    /// <summary>
    ///
    /// </summary>
    [JsonProperty("website_url")]
    public string WebsiteUrl { get; set; }
    /// <summary>
    ///
    /// </summary>
    [JsonProperty("organization_name")]
    public string OrganizationName { get; set; }
    /// <summary>
    /// Street address for your organization
    /// </summary>
    [JsonProperty("street_address")]
    public Location StreetAddress { get; set; }
}