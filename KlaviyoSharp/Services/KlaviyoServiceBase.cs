namespace KlaviyoSharp.Services
{
    public abstract class KlaviyoServiceBase
    {
        protected string _revision;
        protected KlaviyoApiBase _klaviyoService;
        protected KlaviyoServiceBase(string revision, KlaviyoApiBase klaviyoService)
        {
            _revision = revision;
            _klaviyoService = klaviyoService;
        }
    }
}