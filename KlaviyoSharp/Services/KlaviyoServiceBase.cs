namespace KlaviyoSharp.Services
{
    public abstract class KlaviyoServiceBase
    {
        protected string _path;
        protected string _revision;
        protected KlaviyoService _klaviyoService;
        protected KlaviyoServiceBase(string path, string revision, KlaviyoService klaviyoService)
        {
            _path = path;
            _revision = revision;
            _klaviyoService = klaviyoService;
        }
    }
}