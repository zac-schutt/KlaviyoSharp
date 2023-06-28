using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;

namespace KlaviyoSharp.Services
{
    public class ClientProfile : KlaviyoServiceBase
    {
        public ClientProfile(KlaviyoClientApi client) : base("profiles", "2023-06-15", client) { }
        /// <summary>
        /// Create and update properties about a profile without tracking an associated event.
        /// </summary>
        /// <param name="attributes"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Upsert(ClientProfileRequestAttributes attributes, CancellationToken cancellationToken = default)
        {
            await _klaviyoService.POST(_path, null, null, new DataObject<ClientProfileRequestAttributes>("profile", attributes), cancellationToken);
        }
    }
}