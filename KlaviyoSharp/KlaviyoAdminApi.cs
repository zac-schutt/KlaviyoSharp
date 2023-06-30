namespace KlaviyoSharp;
/// <summary>
///
/// </summary>
public class KlaviyoAdminApi : KlaviyoApiBase
{
    public KlaviyoAdminApi(string apiKey) : base()
    {
        _apiPath = "/api";
        _apiKey = apiKey;
    }
    public Services.AccountServices AccountServices { get { _AccountServices ??= new(this); return _AccountServices; } }
    private Services.AccountServices _AccountServices;
    public Services.DataPrivacyServices DataPrivacyServices { get { _DataPrivacyServices ??= new(this); return _DataPrivacyServices; } }
    private Services.DataPrivacyServices _DataPrivacyServices;
    public Services.ListServices ListServices { get { _ListServices ??= new(this); return _ListServices; } }
    private Services.ListServices _ListServices;

    public Services.ProfileServices ProfileServices { get { _ProfileServices ??= new(this); return _ProfileServices; } }
    private Services.ProfileServices _ProfileServices;

}