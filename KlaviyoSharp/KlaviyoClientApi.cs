namespace KlaviyoSharp;
/// <summary>
/// The Klaviyo Client API. All /client endpoints use a public API key, your 6-character company ID, also known as a site ID.
/// </summary>
public class KlaviyoClientApi : KlaviyoApiBase
{
    public KlaviyoClientApi(string companyId) : base()
    {
        _useAuthentication = false;
        _apiPath = "/client";
        _companyId = companyId;
    }

    private Services.ClientServices _ClientServices;

    public Services.ClientServices ClientServices { get { _ClientServices ??= new(this); return _ClientServices; } }
}