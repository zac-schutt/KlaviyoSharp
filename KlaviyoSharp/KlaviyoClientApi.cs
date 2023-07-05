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
    public KlaviyoClientApi(string companyId) : base(new(companyId) { ApiPath = "/client" }) { }

    private Services.ClientServices _ClientServices;
    /// <summary>
    /// Services for /client endpoints
    /// </summary>
    public Services.ClientServices ClientServices { get { _ClientServices ??= new(this); return _ClientServices; } }
}