using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;

namespace KlaviyoSharp.Services
{
    public class ClientEvent : KlaviyoServiceBase
    {
        public ClientEvent(KlaviyoClientApi client) : base("events", "2023-06-15", client) { }
        /// <summary>
        /// Create a new event to track a profile's activity.
        /// </summary>
        /// <param name="attributes"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Create(ClientEventRequestAttributes attributes, CancellationToken cancellationToken = default)
        {
            await _klaviyoService.POST(_path, null, null, new DataObject<ClientEventRequestAttributes>("event", attributes), cancellationToken);
        }
    }
}