using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;

namespace KlaviyoSharp.Services;
/// <summary>
/// Klaviyo Data Privacy Services
/// </summary>
public class DataPrivacyServices : KlaviyoServiceBase, IDataPrivacyServices
{
    /// <summary>
    /// Constructor for Klaviyo Data Privacy Services
    /// </summary>
    /// <param name="klaviyoService"></param>
    public DataPrivacyServices(KlaviyoApiBase klaviyoService) : base("2023-06-15", klaviyoService) { }
    /// <inheritdoc />
    public async Task RequestProfileDeletion(ProfileDeletionRequest profileDeletionRequest, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Post, "data-privacy-deletion-jobs/", _revision, null, null, new DataObject<ProfileDeletionRequest>(profileDeletionRequest), cancellationToken);
    }
}
