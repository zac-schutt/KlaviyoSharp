using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Infrastructure;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;
/// <summary>
/// Klaviyo Profile Services
/// </summary>
public class ProfileServices : KlaviyoServiceBase, IProfileServices
{
    /// <summary>
    /// Constructor for Klaviyo Profile Services
    /// </summary>
    /// <param name="revision"></param>
    /// <param name="klaviyoService"></param>
    public ProfileServices(string revision, KlaviyoApiBase klaviyoService) : base(revision, klaviyoService) { }
    /// <inheritdoc />
    public async Task<DataListObject<Profile>> GetProfiles(List<string> fields = null, List<string> additionalFields = null, IFilter filter = null, string sort = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddAdditionalFields("profile", additionalFields);
        query.AddFieldset("profile", fields);
        query.AddFilter(filter);
        query.AddSort(sort);
        return await _klaviyoService.HTTPRecursive<Profile>(HttpMethod.Get, $"profiles/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<Profile>> CreateProfile(Profile profile, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<Profile>>(HttpMethod.Post, "profiles/", _revision, null, null, new DataObject<Profile>(profile), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObjectWithIncluded<Profile>> GetProfile(string profileId, List<string> listFields = null, List<string> profileFields = null, List<string> segmentFields = null, List<string> additionalFields = null, List<string> includedObjects = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddAdditionalFields("profile", additionalFields);
        query.AddFieldset("list", listFields);
        query.AddFieldset("profile", profileFields);
        query.AddFieldset("segment", segmentFields);
        query.AddIncludes(includedObjects);
        return await _klaviyoService.HTTP<DataObjectWithIncluded<Profile>>(HttpMethod.Get, $"profiles/{profileId}/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<Profile>> UpdateProfile(string profileId, PatchProfile profile, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<Profile>>(new("PATCH"), $"profiles/{profileId}/", _revision, null, null, new DataObject<PatchProfile>(profile), cancellationToken);
    }
    /// <inheritdoc />
    public async Task SuppressProfiles(ProfileSuppressionRequest supressions, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Post, "profile-suppression-bulk-create-jobs/", _revision, null, null, new DataObject<ProfileSuppressionRequest>(supressions), cancellationToken);
    }
    /// <inheritdoc />
    public async Task UnsuppressProfiles(ProfileUnsuppressionRequest unsupressions, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Post, "profile-suppression-bulk-delete-jobs/", _revision, null, null, new DataObject<ProfileUnsuppressionRequest>(unsupressions), cancellationToken);
    }
    /// <inheritdoc />
    public async Task SubscribeProfiles(ProfileSubscriptionRequest profileSubscriptions, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Post, "profile-subscription-bulk-create-jobs/", _revision, null, null, new DataObject<ProfileSubscriptionRequest>(profileSubscriptions), cancellationToken);
    }

    /// <inheritdoc />
    public async Task UnsuscribeProfiles(ProfileUnsubscriptionRequest profileUnsubscriptions, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Post, "profile-subscription-bulk-delete-jobs/", _revision, null, null, new DataObject<ProfileUnsubscriptionRequest>(profileUnsubscriptions), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<List>> GetProfileLists(string profileId, List<string> fields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("list", fields);
        return await _klaviyoService.HTTP<DataListObject<List>>(HttpMethod.Get, $"profiles/{profileId}/lists/", _revision, query, null, null, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<DataListObject<List>> GetProfileSegments(string profileId, List<string> fields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("segment", fields);
        return await _klaviyoService.HTTP<DataListObject<List>>(HttpMethod.Get, $"profiles/{profileId}/segments/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<GenericObject>> GetProfileRelationshipsLists(string id, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataListObject<GenericObject>>(HttpMethod.Get, $"profiles/{id}/relationships/lists/", _revision, null, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<GenericObject>> GetProfileRelationshipsSegments(string id, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataListObject<GenericObject>>(HttpMethod.Get, $"profiles/{id}/relationships/segments/", _revision, null, null, null, cancellationToken);
    }
}
