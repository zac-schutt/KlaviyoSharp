namespace KlaviyoSharp.Services;

/// <summary>
/// Base class for Klaviyo Services
/// </summary>
public abstract class KlaviyoServiceBase
{
    /// <summary>
    /// Klaviyo API revision
    /// </summary>
    protected string _revision;
    /// <summary>
    /// Klaviyo API service
    /// </summary>
    protected KlaviyoApiBase _klaviyoService;
    /// <summary>
    /// Constructor for Klaviyo Services
    /// </summary>
    /// <param name="revision">Version of the Klaviyo API</param>
    /// <param name="klaviyoService">Klaviyo API service</param>
    protected KlaviyoServiceBase(string revision, KlaviyoApiBase klaviyoService)
    {
        _revision = revision;
        _klaviyoService = klaviyoService;
    }
}