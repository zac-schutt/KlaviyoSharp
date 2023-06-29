namespace KlaviyoSharp;
/// <summary>
///
/// </summary>
public class KlaviyoAdminApi : KlaviyoService
{
    public KlaviyoAdminApi(string apiKey) : base()
    {
        _useAuthentication = true;
        _apiPath = "/api";
        _apiKey = apiKey;
    }


}