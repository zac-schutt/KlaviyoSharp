namespace KlaviyoSharp.Services
{
    public abstract class KlaviyoServiceBase
    {
        protected string _revision;
        protected KlaviyoService _klaviyoService;
        protected KlaviyoServiceBase(string revision, KlaviyoService klaviyoService)
        {
            _revision = revision;
            _klaviyoService = klaviyoService;
        }
    }
}