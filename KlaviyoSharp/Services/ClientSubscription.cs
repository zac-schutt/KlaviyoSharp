using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;

namespace KlaviyoSharp.Services
{
    public class ClientSubscription : KlaviyoServiceBase
    {
        public ClientSubscription(KlaviyoClientApi client) : base("subscriptions", "2023-06-15", client) { }
        /// <summary>
        /// Create a new subscription for the given list ID and channel. Must contain either email or phone_number.
        /// </summary>
        /// <param name="attributes"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Subscribe(ClientSubscriptionRequestAttributes attributes, CancellationToken cancellationToken = default)
        {
            await _klaviyoService.POST(_path, null, null, new DataObject<ClientSubscriptionRequestAttributes>("subscription", attributes), cancellationToken);
        }
    }
}