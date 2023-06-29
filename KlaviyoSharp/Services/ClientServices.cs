using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;

namespace KlaviyoSharp.Services
{
    public class ClientServices : KlaviyoServiceBase
    {
        public ClientServices(KlaviyoClientApi client) : base("2023-06-15", client) { }
        /// <summary>
        /// Create a new event to track a profile's activity.
        /// </summary>
        /// <param name="attributes"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task CreateEvent(ClientEventRequestAttributes attributes, CancellationToken cancellationToken = default)
        {
            await _klaviyoService.POST("events", _revision, null, null, new DataObject<ClientEventRequestAttributes>("event", attributes), cancellationToken);
        }

        /// <summary>
        /// Create and update properties about a profile without tracking an associated event.
        /// </summary>
        /// <param name="attributes"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task UpsertProfile(ClientProfileRequestAttributes attributes, CancellationToken cancellationToken = default)
        {
            await _klaviyoService.POST("profiles/", _revision, null, null, new DataObject<ClientProfileRequestAttributes>("profile", attributes), cancellationToken);
        }

        /// <summary>
        /// Create a new subscription for the given list ID and channel. Must contain either email or phone_number.
        /// </summary>
        /// <param name="attributes"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task CreateSubscription(ClientSubscriptionRequestAttributes attributes, CancellationToken cancellationToken = default)
        {
            await _klaviyoService.POST("subscriptions", _revision, null, null, new DataObject<ClientSubscriptionRequestAttributes>("subscription", attributes), cancellationToken);
        }

    }
}