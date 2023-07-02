using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;

namespace KlaviyoSharp.Services;

public class ClientServices : KlaviyoServiceBase, IClientServices
{
    public ClientServices(KlaviyoClientApi klaviyoService) : base("2023-06-15", klaviyoService) { }

    /// <inheritdoc/>
    public async Task CreateEvent(EventRequest clientEvent, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Post, "events", _revision, null, null, new DataObject<EventRequest>(clientEvent), cancellationToken);
    }

    /// <inheritdoc/>
    public async Task UpsertProfile(ClientProfile profile, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Post, "profiles/", _revision, null, null, new DataObject<ClientProfile>(profile), cancellationToken);
    }

    /// <inheritdoc/>
    public async Task CreateSubscription(ClientSubscription subscription, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Post, "subscriptions", _revision, null, null, new DataObject<ClientSubscription>(subscription), cancellationToken);
    }

}
