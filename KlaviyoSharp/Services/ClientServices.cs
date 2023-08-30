using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;

namespace KlaviyoSharp.Services;

/// <summary>
/// Klaviyo Client Services
/// </summary>
public class ClientServices : KlaviyoServiceBase, IClientServices
{
    /// <summary>
    /// Constructor for Klaviyo Client Services
    /// </summary>
    /// <param name="revision"></param>
    /// <param name="klaviyoService"></param>
    public ClientServices(string revision, KlaviyoClientApi klaviyoService) : base(revision, klaviyoService) { }

    /// <inheritdoc/>
    public async Task CreateEvent(EventRequest clientEvent, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Post, "events/", _revision, null, null,
                                   new DataObject<EventRequest>(clientEvent), cancellationToken);
    }

    /// <inheritdoc/>
    public async Task UpsertProfile(ClientProfile profile, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Post, "profiles/", _revision, null, null,
                                   new DataObject<ClientProfile>(profile), cancellationToken);
    }

    /// <inheritdoc/>
    public async Task CreateSubscription(ClientSubscription subscription, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Post, "subscriptions/", _revision, null, null,
                                   new DataObject<ClientSubscription>(subscription), cancellationToken);
    }

    /// <inheritdoc />
    public async Task CreateClientBackInStockSubscription(BackInStockSubscription subscription,
                                                          CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Post, "back-in-stock-subscriptions/", _revision, null, null,
                                   new DataObject<BackInStockSubscription>(subscription), cancellationToken);
    }

    /// <inheritdoc />
    public async Task CreateOrUpdateClientPushToken(PushToken pushToken, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Post, "push-tokens/", _revision, null, null,
                                   new DataObject<PushToken>(pushToken), cancellationToken);
    }
    /// <inheritdoc />
    public async Task UnregisterClientPushToken(PushTokenUnregister pushToken,
                                                CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Post, "push-token-unregister/", _revision, null, null,
                                   new DataObject<PushTokenUnregister>(pushToken), cancellationToken);
    }

    /// <inheritdoc />
    public async Task BulkCreateClientEvents(ClientEventBulkCreate clientEventBulkCreate,
                                             CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Post, "event-bulk-create/", _revision, null, null,
                                   new DataObject<ClientEventBulkCreate>(clientEventBulkCreate), cancellationToken);
    }

}
