namespace KlaviyoSharp.Models;

/// <summary>
/// Klaviyo Account Object
/// </summary>
public class Account : KlaviyoObject<AccountAttributes>
{
    /// <summary>
    /// Creates a new instance of this type and sets the default properties
    /// </summary>
    /// <returns></returns>
    public static new Account Create()
    {
        return new() { Type = "account" };
    }
}

/// <summary>
/// Attributes for a Klaviyo Account
/// </summary>
public class AccountAttributes
{
    /// <summary>
    /// Contact information for the account. This is used in email footers by default to comply with the CAN-SPAM act.
    /// </summary>
    public AccountContactInformation ContactInformation { get; set; }
    /// <summary>
    /// The kind of business and/or types of goods that the business sells. This is leveraged in Klaviyo analytics and
    /// guidance.
    /// </summary>
    public string Industry { get; set; }
    /// <summary>
    /// The account's timezone is used when displaying dates and times. This is an IANA timezone.
    /// </summary>
    public string Timezone { get; set; }
    /// <summary>
    /// The preferred currency for the account. This is the currency used for currency-based metrics in dashboards,
    /// analytics, coupons, and templates.
    /// </summary>
    public string PreferredCurrency { get; set; }
    /// <summary>
    /// The Public API Key can be used for client-side API calls.
    /// </summary>
    public string PublicApiKey { get; set; }
}

/// <summary>
/// Contact information for a account
/// </summary>
public class AccountContactInformation
{
    /// <summary>
    /// This field is used to auto-populate the default sender name on flow and campaign emails.
    /// </summary>
    public string DefaultSenderName { get; set; }
    /// <summary>
    /// This field is used to auto-populate the default sender email address on flow and campaign emails.
    /// </summary>
    public string DefaultSenderEmail { get; set; }
    /// <summary>
    ///
    /// </summary>
    public string WebsiteUrl { get; set; }
    /// <summary>
    ///
    /// </summary>
    public string OrganizationName { get; set; }
    /// <summary>
    /// Street address for your organization
    /// </summary>
    public AccountStreetAddress StreetAddress { get; set; }
}

/// <summary>
/// Street address for a account
/// </summary>
public class AccountStreetAddress
{
    /// <summary>
    /// First line of street address
    /// </summary>
    public string Address1 { get; set; }
    /// <summary>
    /// First line of street address
    /// </summary>
    public string Address2 { get; set; }
    /// <summary>
    /// City name
    /// </summary>
    public string City { get; set; }
    /// <summary>
    /// Country name
    /// </summary>
    public string Country { get; set; }
    /// <summary>
    /// Region within a country, such as state or province
    /// </summary>
    public string Region { get; set; }
    /// <summary>
    /// Zip code
    /// </summary>
    public string Zip { get; set; }
}