using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;

namespace KlaviyoSharp.Services;

public class DataPrivacyServices : KlaviyoServiceBase, IDataPrivacyServices
{
    public DataPrivacyServices(KlaviyoApiBase klaviyoService) : base("2023-06-15", klaviyoService) { }
    /// <inheritdoc />
    public async Task RequestProfileDeletion(ProfileDeletionAttributes attributes, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Post, "data-privacy-deletion-jobs/", _revision, null, null, new DataObject<ProfileDeletionAttributes>("data-privacy-deletion-job", attributes), cancellationToken);
    }
}
