using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class Account
{
    /// <summary>
    /// Contact information for the account. This is used in email footers by default to comply with the CAN-SPAM act.
    /// </summary>
    [JsonProperty("contact_information")]
    public ContactInformation ContactInformation { get; set; }
    /// <summary>
    /// The kind of business and/or types of goods that the business sells. This is leveraged in Klaviyo analytics and guidance.
    /// </summary>
    [JsonProperty("industry")]
    public string Industry { get; set; }
    /// <summary>
    /// The account's timezone is used when displaying dates and times. This is an IANA timezone.
    /// </summary>
    [JsonProperty("timezone")]
    public string Timezone { get; set; }
    /// <summary>
    /// The preferred currency for the account. This is the currency used for currency-based metrics in dashboards, analytics, coupons, and templates.
    /// </summary>
    [JsonProperty("preferred_currency")]
    public string PreferredCurrency { get; set; }
    /// <summary>
    /// The Public API Key can be used for client-side API calls.
    /// </summary>
    [JsonProperty("public_api_key")]
    public string PublicApiKey { get; set; }
}
