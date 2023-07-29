namespace KlaviyoSharp;
/// <summary>
/// The Klaviyo Admin API. All /api endpoints use a private API key.
/// </summary>
public class KlaviyoAdminApi : KlaviyoApiBase
{
    const string REVISION = "2023-06-15";
    /// <summary>
    /// Creates a new instance of the Klaviyo Admin API.
    /// </summary>
    /// <param name="apiKey">Your private API key.</param>
    public KlaviyoAdminApi(string apiKey) : this(new KlaviyoConfig(apiKey)) { }
    /// <summary>
    /// Creates a new instance of the Klaviyo Admin API.
    /// </summary>
    /// <param name="config">The KlaviyoConfig object.</param>
    public KlaviyoAdminApi(KlaviyoConfig config) : base(config) { }
    /// <summary>
    /// Services for interacting with the Klaviyo Account
    /// </summary>
    public Services.AccountServices AccountServices { get { _AccountServices ??= new(REVISION, this); return _AccountServices; } }
    private Services.AccountServices _AccountServices;
    /// <summary>
    /// Services for interacting with the Klaviyo Data Privacy API
    /// </summary>
    public Services.DataPrivacyServices DataPrivacyServices { get { _DataPrivacyServices ??= new(REVISION, this); return _DataPrivacyServices; } }
    private Services.DataPrivacyServices _DataPrivacyServices;
    /// <summary>
    /// Services for interacting with the Klaviyo Lists API
    /// </summary>
    public Services.ListServices ListServices { get { _ListServices ??= new(REVISION, this); return _ListServices; } }
    private Services.ListServices _ListServices;
    /// <summary>
    /// Services for interacting with the Klaviyo Profiles API
    /// </summary>
    public Services.ProfileServices ProfileServices { get { _ProfileServices ??= new(REVISION, this); return _ProfileServices; } }
    private Services.ProfileServices _ProfileServices;
    /// <summary>
    /// Services for interacting with the Klaviyo Metrics API
    /// </summary>
    public Services.MetricServices MetricServices { get { _MetricServices ??= new(REVISION, this); return _MetricServices; } }
    private Services.MetricServices _MetricServices;
    /// <summary>
    /// Services for interacting with the Klaviyo Events API
    /// </summary>
    public Services.EventServices EventServices { get { _EventServices ??= new(REVISION, this); return _EventServices; } }
    private Services.EventServices _EventServices;
    /// <summary>
    /// Services for interacting with the Klaviyo Segments API
    /// </summary>
    public Services.SegmentServices SegmentServices { get { _SegmentServices ??= new(REVISION, this); return _SegmentServices; } }
    private Services.SegmentServices _SegmentServices;
    /// <summary>
    /// Services for interacting with the Klaviyo Templates API
    /// </summary>
    public Services.TemplateServices TemplateServices { get { _TemplateServices ??= new(REVISION, this); return _TemplateServices; } }
    private Services.TemplateServices _TemplateServices;
    /// <summary>
    /// Services for interacting with the Klaviyo Flows API
    /// </summary>
    public Services.FlowServices FlowServices { get { _FlowServices ??= new(REVISION, this); return _FlowServices; } }
    private Services.FlowServices _FlowServices;
    /// <summary>
    /// Services for interacting with the Klaviyo Tags API
    /// </summary>
    public Services.TagServices TagServices { get { _TagServices ??= new(REVISION, this); return _TagServices; } }
    private Services.TagServices _TagServices;
    /// <summary>
    /// Services for interacting with the Klaviyo Campaigns API
    /// </summary>
    public Services.CampaignServices CampaignServices { get { _CampaignServices ??= new(REVISION, this); return _CampaignServices; } }
    private Services.CampaignServices _CampaignServices;
    /// <summary>
    /// Services for interacting with the Klaviyo Catalogs API
    /// </summary>
    public Services.CatalogServices CatalogServices { get { _CatalogServices ??= new(REVISION, this); return _CatalogServices; } }
    private Services.CatalogServices _CatalogServices;
}