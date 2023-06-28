namespace KlaviyoSharp;
/// <summary>
/// The Klaviyo Client API. All /client endpoints use a public API key, your 6-character company ID, also known as a site ID.
/// </summary>
public class KlaviyoClientApi : KlaviyoService
{
    public KlaviyoClientApi(string companyId) : base()
    {
        _useAuthentication = false;
        _apiPath = "/client";
        _companyId = companyId;
        ClientSubscription = new(this);
        ClientEvent = new(this);
    }

    public Services.ClientSubscription ClientSubscription { get; set; }
    public Services.ClientEvent ClientEvent { get; set; }
}