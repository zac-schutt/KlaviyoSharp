using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Infrastructure;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;

public class ProfileServices : KlaviyoServiceBase, IProfileServices
{
    public ProfileServices(KlaviyoApiBase klaviyoService) : base("2023-06-15", klaviyoService) { }
    /// <inheritdoc />
    public async Task<List<DataObject<ProfileAttributes>>> GetProfiles(List<string> fields = null, List<string> additionalFields = null, IFilter filter = null, string sort = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddAdditionalFields("profile", additionalFields);
        query.AddFieldset("profile", fields);
        query.AddFilters(filter);
        query.AddSort(sort);
        List<DataObject<ProfileAttributes>> output = new();
        string pageCursor = "";
        ResponseBody<List<DataObject<ProfileAttributes>>> response;
        query.Add("page[cursor]", pageCursor);
        do
        {
            query["page[cursor]"] = pageCursor;
            response = await _klaviyoService.HTTP<ResponseBody<List<DataObject<ProfileAttributes>>>>(HttpMethod.Get, $"profiles/", _revision, query, null, null, cancellationToken);
            output.AddRange(response.Data);
            pageCursor = new QueryParams(response.Links.Next).GetValueOrDefault("page[cursor]");
        } while (response.Links.Next != null);
        return output;
    }
    /// <inheritdoc />
    public async Task<DataObject<ProfileAttributes>> CreateProfile(ProfileAttributes profileAttributes, CancellationToken cancellationToken = default)
    {
        return (await _klaviyoService.HTTP<ResponseBody<DataObject<ProfileAttributes>>>(HttpMethod.Post, "profiles/", _revision, null, null, new DataObject<ProfileAttributes>("profile", profileAttributes), cancellationToken)).Data;
    }
    /// <inheritdoc />
    public async Task<DataObject<ProfileAttributes>> GetProfile(string profileId, List<string> listFields = null, List<string> profileFields = null, List<string> segmentFields = null, List<string> additionalFields = null, List<string> includedObjects = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddAdditionalFields("profile", additionalFields);
        query.AddFieldset("list", listFields);
        query.AddFieldset("profile", profileFields);
        query.AddFieldset("segment", segmentFields);
        includedObjects?.ForEach(x => query.Add("include", x));
        return (await _klaviyoService.HTTP<ResponseBody<DataObject<ProfileAttributes>>>(HttpMethod.Get, $"profiles/{profileId}/", _revision, query, null, null, cancellationToken)).Data;
    }
    /// <inheritdoc />
    public async Task<DataObject<ProfileAttributes>> UpdateProfile(string profileId, ProfileAttributes profileAttributes, CancellationToken cancellationToken = default)
    {
        return (await _klaviyoService.HTTP<ResponseBody<DataObject<ProfileAttributes>>>(HttpMethod.Patch, $"profiles/{profileId}/", _revision, null, null, new DataObject<ProfileAttributes>("profile", profileId, profileAttributes), cancellationToken)).Data;
    }
    /// <inheritdoc />
    public async Task SuppressProfiles(SupressionAttributes supressionAttributes, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP<ResponseBody<object>>(HttpMethod.Post, "profile-suppression-bulk-create-jobs/", _revision, null, null, new DataObject<SupressionAttributes>("profile-suppression-bulk-create-job", supressionAttributes), cancellationToken);
    }
    /// <inheritdoc />
    public async Task UnsuppressProfiles(SupressionAttributes supressionAttributes, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP<ResponseBody<object>>(HttpMethod.Post, "profile-unsuppression-bulk-create-jobs/", _revision, null, null, new DataObject<SupressionAttributes>("profile-unsuppression-bulk-create-job", supressionAttributes), cancellationToken);
    }
    /// <inheritdoc />
    public async Task SubscribeProfiles(ProfileSubscriptionAttributes profileSubscriptionAttributes, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP<ResponseBody<object>>(HttpMethod.Post, "profile-subscription-bulk-create-jobs/", _revision, null, null, new DataObject<ProfileSubscriptionAttributes>("profile-subscription-bulk-create-job", profileSubscriptionAttributes), cancellationToken);
    }

    /// <inheritdoc />
    public async Task UnsuscribeProfiles(ProfileUnsubscriptionAttributes profileUnsubscriptionAttributes, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP<ResponseBody<object>>(HttpMethod.Post, "profile-unsubscription-bulk-create-jobs/", _revision, null, null, new DataObject<ProfileUnsubscriptionAttributes>("profile-unsubscription-bulk-create-job", profileUnsubscriptionAttributes), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<List<DataObject<ListAttributes>>> GetProfileLists(string profileId, List<string> fields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("list", fields);
        return (await _klaviyoService.HTTP<ResponseBody<List<DataObject<ListAttributes>>>>(HttpMethod.Get, $"profiles/{profileId}/lists/", _revision, query, null, null, cancellationToken)).Data;
    }

    /// <inheritdoc />
    public async Task<List<DataObject<ListAttributes>>> GetProfileSegments(string profileId, List<string> fields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("segment", fields);
        return (await _klaviyoService.HTTP<ResponseBody<List<DataObject<ListAttributes>>>>(HttpMethod.Get, $"profiles/{profileId}/segments/", _revision, query, null, null, cancellationToken)).Data;
    }
    /// <inheritdoc />
    public async Task<List<DataObject>> GetProfileRelationshipsLists(string id, CancellationToken cancellationToken = default)
    {
        return (await _klaviyoService.HTTP<ResponseBody<List<DataObject>>>(HttpMethod.Get, $"profiles/{id}/relationships/lists/", _revision, null, null, null, cancellationToken)).Data;
    }
    /// <inheritdoc />
    public async Task<List<DataObject>> GetProfileRelationshipsSegments(string id, CancellationToken cancellationToken = default)
    {
        return (await _klaviyoService.HTTP<ResponseBody<List<DataObject>>>(HttpMethod.Get, $"profiles/{id}/relationships/segments/", _revision, null, null, null, cancellationToken)).Data;
    }
}
