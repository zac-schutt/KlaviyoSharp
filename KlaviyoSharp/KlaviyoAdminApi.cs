namespace KlaviyoSharp;
/// <summary>
///
/// </summary>
public class KlaviyoAdminApi : KlaviyoApiBase
{

    public KlaviyoAdminApi(string apiKey) : base(new(apiKey)) { }
    public Services.AccountServices AccountServices { get { _AccountServices ??= new(this); return _AccountServices; } }
    private Services.AccountServices _AccountServices;
    public Services.DataPrivacyServices DataPrivacyServices { get { _DataPrivacyServices ??= new(this); return _DataPrivacyServices; } }
    private Services.DataPrivacyServices _DataPrivacyServices;
    public Services.ListServices ListServices { get { _ListServices ??= new(this); return _ListServices; } }
    private Services.ListServices _ListServices;

    public Services.ProfileServices ProfileServices { get { _ProfileServices ??= new(this); return _ProfileServices; } }
    private Services.ProfileServices _ProfileServices;

    public Services.MetricServices MetricServices { get { _MetricServices ??= new(this); return _MetricServices; } }
    private Services.MetricServices _MetricServices;

    public Services.EventServices EventServices { get { _EventServices ??= new(this); return _EventServices; } }
    private Services.EventServices _EventServices;
}