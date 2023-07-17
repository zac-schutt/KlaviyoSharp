namespace KlaviyoSharp;
/// <summary>
/// The Klaviyo Client API. All /client endpoints use a public API key, your 6-character company ID, also known as a site ID.
/// </summary>
public class KlaviyoClientApi : KlaviyoApiBase
{
    /// <summary>
    /// Creates a new instance of the Klaviyo Client API.
    /// </summary>
    /// <param name="companyId">Your 6-character company ID, also known as a site ID.</param>
    public KlaviyoClientApi(string companyId) : this(new KlaviyoConfig(companyId) { ApiPath = "/client", UseAuthentication = false }) { }
    /// <summary>
    /// Creates a new instance of the Klaviyo Client API.
    /// </summary>
    /// <param name="config">The KlaviyoConfig object.</param>
    public KlaviyoClientApi(KlaviyoConfig config) : base(config) { }

    private Services.ClientServices _ClientServices;
    /// <summary>
    /// Services for /client endpoints
    /// </summary>
    public Services.ClientServices ClientServices { get { _ClientServices ??= new(this); return _ClientServices; } }
}