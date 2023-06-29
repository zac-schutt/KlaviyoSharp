using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;

namespace KlaviyoSharp.Services;

public class ClientServices : KlaviyoServiceBase, IClientServices
{
    public ClientServices(KlaviyoClientApi klaviyoService) : base("2023-06-15", klaviyoService) { }

    /// <inheritdoc/>
    public async Task CreateEvent(ClientEventRequestAttributes attributes, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.POST("events", _revision, null, null, new DataObject<ClientEventRequestAttributes>("event", attributes), cancellationToken);
    }

    /// <inheritdoc/>
    public async Task UpsertProfile(ClientProfileRequestAttributes attributes, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.POST("profiles/", _revision, null, null, new DataObject<ClientProfileRequestAttributes>("profile", attributes), cancellationToken);
    }

    /// <inheritdoc/>
    public async Task CreateSubscription(ClientSubscriptionRequestAttributes attributes, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.POST("subscriptions", _revision, null, null, new DataObject<ClientSubscriptionRequestAttributes>("subscription", attributes), cancellationToken);
    }

}
