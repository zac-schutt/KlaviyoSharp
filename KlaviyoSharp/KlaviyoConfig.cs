namespace KlaviyoSharp;

/// <summary>
/// Configuration Parameters for the Klaviyo API
/// </summary>
public class KlaviyoConfig
{
    public KlaviyoConfig(string apiKey)
    {
        ApiKey = apiKey;
    }
    /// <summary>
    /// The API Key for the Klaviyo Account
    /// </summary>
    public string ApiKey { get; set; }
    /// <summary>
    /// The API Domain for the Klaviyo Account. Defaults to https://a.klaviyo.com
    /// </summary>
    public string ApiDomain { get; set; } = "https://a.klaviyo.com";
    /// <summary>
    /// The API Path for the Klaviyo Account. Defaults to /api
    /// </summary>
    public string ApiPath { get; set; } = "/api";
    /// <summary>
    /// Whether to use authentication (API Key in header), or just append the apikey in the company_id query string. Defaults to true.
    /// </summary>
    public bool UseAuthentication { get; set; } = true;
    /// <summary>
    /// The maximum delay between retries in seconds. Defaults to 60.
    /// </summary>
    public int MaxDelay { get; set; } = 60;
    /// <summary>
    /// The maximum number of retries. Defaults to 3.
    /// </summary>
    public int MaxRetries { get; set; } = 3;

}