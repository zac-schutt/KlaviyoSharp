namespace KlaviyoSharp;
/// <summary>
///
/// </summary>
public class KlaviyoAdminApi : KlaviyoApiBase
{
    public KlaviyoAdminApi(string apiKey) : base()
    {
        _useAuthentication = true;
        _apiPath = "/api";
        _apiKey = apiKey;
    }

    private Services.AccountServices _AccountServices;
    public Services.AccountServices AccountServices { get { _AccountServices ??= new(this); return _AccountServices; } }

    private Services.DataPrivacyServices _DataPrivacyServices;
    public Services.DataPrivacyServices DataPrivacyServices { get { _DataPrivacyServices ??= new(this); return _DataPrivacyServices; } }
}